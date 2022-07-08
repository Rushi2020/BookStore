using BusinessLayer.Interface;
using DatabaseLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        IWishListBL wishlistBL;

        public WishListController(IWishListBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }

        [Authorize(Roles = Role.User)]
        [HttpPost("AddWishlist")]
        public ActionResult AddBookToWishlist(WishListModel wishListModel)
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);

                string result = this.wishlistBL.AddBookToWishlist(wishListModel ,id);
                if (result.Equals("Book added to WishList successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpDelete("DeleteWishlist")]
        public ActionResult DeleteWishlist(int WishListId)
        {
            try
            {
                string result = this.wishlistBL.DeleteWishlist(WishListId);
                if (result.Equals("Book deleted in WishList successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [Authorize(Roles = Role.User)]
        [HttpGet]
        public ActionResult GetWishlistData()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "userId").Value);
                var result = this.wishlistBL.GetWishListData(id);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "These are the Books in wishlist are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
