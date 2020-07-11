using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductBrand> productBrandRepo,
                                  IGenericRepository<ProductType> productTypeRepo,
                                  IMapper mapper)
        {
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _productsRepo = productsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetAllProducts()
        {
            // var products = await _productsRepo.ListAllAsync();
            // return Ok(products);
            var spec = new ProductsWithTypesAndBrandsSpec();
            var products = await _productsRepo.ListAsyncWithSpec(spec);
            return 
                Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResponseDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            // var product = await _productsRepo.GetByIdAsync(id);
            // if (product != null)
            //     return Ok(product);

            // return NotFound();
            var spec = new ProductsWithTypesAndBrandsSpec(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            if (product != null)
                return Ok(_mapper.Map<Product, ProductResponseDto>(product));

            return NotFound();
        }

        [HttpGet]
        [Route("brands")]
        public async Task<ActionResult<Product>> GetAllProductBrands()
        {
            var brands = await _productBrandRepo.ListAllAsync();
            return Ok(brands);
        }

        [HttpGet]
        [Route("types")]
        public async Task<ActionResult<ProductType>> GetAllProductTypes()
        {
            var types = await _productTypeRepo.ListAllAsync();
            return Ok(types);
        }
    }
}