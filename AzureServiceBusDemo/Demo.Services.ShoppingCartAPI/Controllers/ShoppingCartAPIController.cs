using AutoMapper;
using Demo.Services.ShoppingCartAPI.DTOs;
using Demo.Services.ShoppingCartAPI.Interfaces;
using Demo.Services.ShoppingCartAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Demo.Services.ShoppingCartAPI.Controllers
{
    /// <summary>
    /// Class ShoppingCartAPIController contains CRUD endpoints for ShoppingCart excluding update.
    /// </summary>
    [ApiController]
    [Route("api/shoppingcart")]
    public class ShoppingCartAPIController : ControllerBase
    {
        private readonly IShoppingCartService _context;
        private readonly IMapper _mapper;

        private readonly string _notFoundMsg = "Shopping Cart or item was not found.";
        private readonly string _badRequestdMsg = "Id is not valid.";

        public ShoppingCartAPIController(IShoppingCartService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a single shopping cart by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{cartId:Guid}", Name = "GetShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShoppingCartDTO>> GetShoppingCart(Guid cartId)
        {
            if (cartId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var cart = await _context.GetShoppingCartById(cartId);

            if (cart == null)
            {
                return NotFound(_notFoundMsg);
            }

            return Ok(_mapper.Map<ShoppingCartDTO>(cart));
        }

        /// <summary>
        /// Adds a product detail to existing shopping cart
        /// </summary>
        /// <param name="cartDetailDTO"></param>
        /// <returns></returns>
        [HttpPost("AddToCart")]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ShoppingCartDTO>> AddToShoppingCart(ShoppingCartDetailDTO cartDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cartDetailDTO == null)
            {
                return BadRequest("Item is needed to add to a cart.");
            }

            if (cartDetailDTO.ShoppingCartId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var cartDetail = _mapper.Map<ShoppingCartDetail>(cartDetailDTO);
            cartDetail = await _context.AddToShoppingCart(cartDetail);

            if (cartDetail == null)
            {
                return NotFound(_notFoundMsg);
            }

            return CreatedAtRoute("GetShoppingCart", new { id = cartDetail.ShoppingCartId }, cartDetail.ShoppingCart);
        }

        /// <summary>
        /// Deletes a product detail from existing shopping cart
        /// </summary>
        /// <param name="productDetailId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteItem/{productDetailId:Guid}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveFromShoppingCart(Guid productDetailId)
        {
            if (productDetailId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var cartDetail =  await _context.RemoveFromShoppingCart(productDetailId);

            if (cartDetail == null)
            {
                return NotFound(_notFoundMsg);
            }

            return NoContent();
        }

        /*
         *  NOT WORKING!
         */
        //[HttpPatch]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<ShoppingCartDetailDTO>> PatchShoppingCartDetail(Guid id, [FromBody] Microsoft.AspNetCore.JsonPatch.JsonPatchDocument<ShoppingCartDetailDTO> cartDetailDTO)
        //{
        //    if (id == Guid.Empty)
        //    {
        //        return BadRequest(_badRequestdMsg);
        //    }

        //    var cartDetailFromDb = _context.GetShoppingCartDetailById(id);

        //    if (cartDetailFromDb == null)
        //    {
        //        return NotFound();
        //    }

        //    var cartDetailFromDbAsDTO = _mapper.Map<ShoppingCartDetailDTO>(cartDetailFromDb);

        //    cartDetailDTO.ApplyTo(cartDetailFromDbAsDTO, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Invalid model.");
        //    }
        //    var cartDetail = _mapper.Map<ShoppingCartDetail>(cartDetailFromDbAsDTO);

        //    var updatedCartDetail = await _context.PatchShoppingCartDetail(cartDetail);

        //    if (updatedCartDetail == null)
        //    {
        //        return NotFound("Shopping cart was not found.");
        //    }

        //    return NoContent();
        //}

        /// <summary>
        /// Creates a new shopping cart if the user doesn't have an active shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("Create/{userId:Guid}", Name = "CreateShoppingCart")]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ShoppingCartDTO>> CreateCart(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var shoppingCart = await _context.CreateShoppingCart(userId);

            if (shoppingCart == null)
            {
                return BadRequest("Shopping cart for this user already exists.");
            }

            return Ok(_mapper.Map<ShoppingCartDTO>(shoppingCart));
        }

        /// <summary>
        /// Clears an existing shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpPost("ClearCart/{cartId:Guid}")]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ShoppingCartDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ShoppingCartDTO>> ClearCart(Guid cartId)
        {
            if (cartId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var isSuccess = await _context.ClearShoppingCart(cartId);

            if (!isSuccess)
            {
                return NotFound(_notFoundMsg);
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes an existing shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>
        [HttpDelete("DeleteCart/{userId:Guid}/{cartId:Guid}", Name = "DeleteCart")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCart(Guid userId, Guid cartId)
        {
            if (userId == Guid.Empty || cartId == Guid.Empty)
            {
                return BadRequest("User id and cart id is required.");
            }

            var isSuccess = await _context.DeleteCartAsync(userId, cartId);

            if (!isSuccess)
            {
                return NotFound($"Shopping cart for UserId: {userId} was not found");
            }

            return NoContent();
        }
    }
}
