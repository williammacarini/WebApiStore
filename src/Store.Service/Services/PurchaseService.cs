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

        public PurchaseService(IPurchaseRepository purchaseRepository, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreatePurchaseAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var validate = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Erro na validação!", validate);

            var productId = await _productRepository.GetIdByCodeAsync(purchaseDTO.Code);
            var userId = await _userRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            var purchase = new Purchase(productId, userId);

            var data = await _purchaseRepository.CreatePurchaseAsync(purchase);
            purchaseDTO.PurchaseId = data.PurchaseId;
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }

        public async Task<ResultService> DeletePurchaseAsync(int purchaseId)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(purchaseId);
            if (purchase == null)
                return ResultService.Fail("Compra não encontrada!");

            await _purchaseRepository.DeleteAsync(purchase);
            return ResultService.Ok($"Compra deletada com Id: {purchaseId}!");
        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAllPurchasesAsync()
        {
            var purchases = await _purchaseRepository.GetPurchasesAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailDTO>> GetByPurchaseIdAsync(int purchaseId)
        {
            var purchase = await _purchaseRepository.GetByIdAsync(purchaseId);
            if (purchase == null)
                return ResultService.Fail<PurchaseDetailDTO>($"Compra não encontrada!");

            return ResultService.Ok<PurchaseDetailDTO>(_mapper.Map<PurchaseDetailDTO>(purchase));
        }

        public async Task<ResultService<PurchaseDTO>> UpdatePurchaseAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var result = new PurchaseDTOValidator().Validate(purchaseDTO);

            if (!result.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problema na validação!", result);

            var purchase = await _purchaseRepository.GetByIdAsync(purchaseDTO.PurchaseId);

            if (purchase == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada!");

            var productId = await _productRepository.GetIdByCodeAsync(purchaseDTO.Code);
            var userId = await _userRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            purchase.Edit(purchase.PurchaseId, productId, userId);
            await _purchaseRepository.UpdateAsync(purchase);
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }
    }
}
