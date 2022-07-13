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
    }
}
