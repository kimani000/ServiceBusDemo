using AutoMapper;
using Azure;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Interfaces;
using Demo.Services.CompanyAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Demo.Services.CompanyAPI.Controllers
{
    /// <summary>
    /// Class ProductAPIController contains CRUD endpoints for Company
    /// </summary>
    [ApiController]
    [Route("api/product")]
    public class ProductAPIController : ControllerBase
    {
        private readonly IProductService _context;
        private readonly IMapper _mapper;

        private readonly string _notFoundMsg = "Product was not found.";
        private readonly string _badRequestdMsg = "Product id is not valid.";

        public ProductAPIController(IProductService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _context.GetProductsAsync();

            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        [HttpGet("{id:Guid}", Name = "GetProduct")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var product = await _context.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound(_notFoundMsg);
            }

            return Ok(_mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] ProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productDTO == null)
            {
                return BadRequest(productDTO);
            }

            if (productDTO.Id != Guid.Empty)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Can not add product with an id");
            }

            var product = _mapper.Map<Product>(productDTO);

            product = await _context.AddProductAsync(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id:Guid}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var product = await _context.DeleteProductAsync(id);

            if (product == null)
            {
                return NotFound(_notFoundMsg);
            }

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDTO productDTO)
        {
            if (productDTO == null || id != productDTO.Id)
            {
                return BadRequest("Invalid Input: Product is null OR id does not match the productId");
            }

            var product = _mapper.Map<Product>(productDTO);

            await _context.UpdateProductAsync(product);

            return NoContent();
        }

        [HttpPatch("/api/product")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PatchProduct(Guid id, [FromBody]JsonPatchDocument<ProductDTO> productDTO)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Input: Product Id is null");
            }

            var productFromDb = await _context.GetProductByIdAsync(id, false);

            if (productFromDb == null)
            {
                return BadRequest(_badRequestdMsg);
            }

            var productDTOfromDb = _mapper.Map<ProductDTO>(productFromDb);

            productDTO.ApplyTo(productDTOfromDb, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Product>(productDTOfromDb);

            await _context.PatchProductAsync(product);

            return NoContent();

            /*
             * NOTE FOR KEITH:
             *  Got patch to work with above code but the request body has to be in the following format:
    
                 [
                   {
                     "op": "replace",
                     "path": "/Name",
                     "value": "NotSneaker"
                   },
                   {
                     "op": "replace",
                     "path": "/Price",
                     "value": 1
                   }
                 ]

                Flow:
                    1. Get the product for db WITHOUT TRACKING
                    2. Null check
                    3. Map the product from db to a productDto
                    4. Apply patch to the obj in step 3
                    5. ModelState check
                    6. Map it back to a product
                    7. Call PatchProductAsync with obj from step 6 as param
                        a. Track it by modifying the entry's state
                        b. SaveChangesAsync
                    8. DONE!
             */
        }
    }
}
