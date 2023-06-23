using AutoMapper;
using Store.Domain.Entities;
using Store.Domain.Repositories;
using Store.Service.DTOs;
using Store.Service.DTOs.Validations;
using Store.Service.Services.Interfaces;

namespace Store.Service.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultService<PurchaseDto>> CreatePurchaseAsync(PurchaseDto purchaseDto)
        {
            if (purchaseDto == null)
                return ResultService.Fail<PurchaseDto>("Objeto deve ser informado!");

            var validate = new PurchaseDtoValidator().Validate(purchaseDto);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDto>("Erro na validação!", validate);

            try
            {
                await _unitOfWork.BeginTransaction();
                var productId = await _productRepository.GetIdByCodeAsync(purchaseDto.Code);
                if (productId == 0)
                {
                    var product = new Product(purchaseDto.ProductName, purchaseDto.Code, purchaseDto.ProductPrice ?? 0);
                    await _productRepository.CreateProductAsync(product);
                    productId = product.ProductId;
                }

                var userId = await _userRepository.GetIdByDocumentAsync(purchaseDto.Document);
                var purchase = new Purchase(productId, userId);

                var data = await _purchaseRepository.CreatePurchaseAsync(purchase);
                purchaseDto.PurchaseId = data.PurchaseId;
                await _unitOfWork.Commit();
                return ResultService.Ok(purchaseDto);
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
                return ResultService.Fail<PurchaseDto>($"{ex}");
            }

        }

        public async Task<ResultService> DeletePurchaseAsync(int purchaseId)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(purchaseId);
            if (purchase == null)
                return ResultService.Fail("Compra não encontrada!");

            await _purchaseRepository.DeleteAsync(purchase);
            return ResultService.Ok($"Compra deletada com Id: {purchaseId}!");
        }

        public async Task<ResultService<ICollection<PurchaseDetailDto>>> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseRepository.GetPurchasesAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDto>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailDto>> GetByPurchaseIdAsync(int purchaseId)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(purchaseId);
            if (purchase == null)
                return ResultService.Fail<PurchaseDetailDto>($"Compra não encontrada!");

            return ResultService.Ok(_mapper.Map<PurchaseDetailDto>(purchase));
        }

        public async Task<ResultService<PurchaseDto>> UpdatePurchaseAsync(PurchaseDto purchaseDTO)
        {
            if (purchaseDTO == null)
                ResultService.Fail<PurchaseDto>("Objeto deve ser informado!");

            var result = new PurchaseDtoValidator().Validate(purchaseDTO);

            if (!result.IsValid)
                return ResultService.RequestError<PurchaseDto>("Problema na validação!", result);

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.PurchaseId);

            if (purchase == null)
                return ResultService.Fail<PurchaseDto>("Compra não encontrada!");

            var productId = await _productRepository.GetIdByCodeAsync(purchaseDTO.Code);
            var userId = await _userRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            purchase.Edit(purchase.PurchaseId, productId, userId);
            await _purchaseRepository.UpdateAsync(purchase);
            return ResultService.Ok(purchaseDTO);
        }
    }
}
