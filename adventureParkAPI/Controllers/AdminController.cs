using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace adventureParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        booking_tableDB bookingDB = new booking_tableDB();
        event_tableDB eventDB = new event_tableDB();
        faq_tableDB faqDB = new faq_tableDB();
        foodCourt_tableDB foodCourtDB = new foodCourt_tableDB();
        gallery_tableDB galleryDB = new gallery_tableDB();
        inquiry_tableDB inquiryDB = new inquiry_tableDB();
        offers_tableDB offersDB = new offers_tableDB();
        package_tableDB packageDB = new package_tableDB();
        review_tableDB reviewDB = new review_tableDB();
        user_tableDB userDB = new user_tableDB();
        
        //Photo Upload
        private String photoUpload(IFormFileCollection Files,String path)
        {
            Random _random = new Random();
            var file = Files[0];
            var folderName = Path.Combine("uploads", path);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = "IMG_" + _random.Next(1, 999) + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return dbPath;

        }
        //showbooking
        [HttpGet("GetDataById/{userID}")]
        public JsonResult GetDataById(int userID)
        {
            List<booking_tableEntities> booking = bookingDB.OnGetDataById(userID);
            if (booking.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Booking List Found", data = booking });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Booking List Not Found", data = booking });
            }

        }
        //forget
        [HttpGet("getUserbyemail/{email}")]
        public JsonResult getUserbyemail(string email)
        {
            user_tableEntities user = userDB.OnGetDatabyemail(email);
            if (user.UserIdPk != 0)
            {
                return new JsonResult(new { result = "success", message = "User Data Found", data = user });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "User Data Not Found", data = user });
            }

        }
        //Login

        [HttpPost("Login")]
        public JsonResult LoginData(user_tableEntities user)
        {
            user_tableEntities result = userDB.LoginData(user.Email, user.Password);

            if (result.UserIdPk != 0)
            {
                return new JsonResult(new { result = "success", message = "User Login successfully", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "User Not Logged In", data = result });
            }
        }
        //Booking
        [HttpGet("bookingList")]
        public JsonResult bookingList()
        {
            List<booking_tableEntities> booking = bookingDB.OnGetListdt();
            if (booking.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Booking List Found", data = booking });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Booking List Not Found", data = booking });
            }
        }

        [HttpGet("bookingData/{id}")]
        public JsonResult bookingData(int id)
        {
            booking_tableEntities booking = bookingDB.OnGetData(id);
            if (booking != null)
            {
                return new JsonResult(new { result = "success", message = "Booking Data Found", data = booking });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Booking Data Not Found", data = booking });
            }
        }

        [HttpPost("insertbooking")]
        public JsonResult insertbooking(booking_tableEntities booking)
        {
            int result = bookingDB.OnInsert(booking);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Booking Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Booking Not Inserted", data = result });
            }
        }

        [HttpPost("updatebooking")]
        public JsonResult updatebooking(booking_tableEntities booking)
        {
            int result = bookingDB.OnUpdate(booking);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Booking Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Booking Not Updated", data = result });
            }
        }
        [HttpDelete("deletebooking/{id}")]
        public JsonResult deletebooking(int id)
        {
            int result = bookingDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Booking Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Booking Not Deleted", data = result });
            }
        }

        //Event
        [HttpGet("EventList")]
        public JsonResult EventList()
        {
            List<event_tableEntities> Event = eventDB.OnGetListdt();
            if (Event.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "Event List Found", data = Event });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Event List Not Found", data = Event });
            }
        }

        [HttpGet("eventData/{id}")]
        public JsonResult eventData(int id)
        {
            event_tableEntities Event = eventDB.OnGetData(id);
            if (Event != null)
            {
                return new JsonResult(new { result = "success", message = "Event Data Found", data = Event });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Event Data Not Found", data = Event });
            }
        }

        [HttpPost("insertEvent")]
        public JsonResult insertEvent()
        {
            event_tableEntities Event = new event_tableEntities();
            Event.EventName = Request.Form["eventName"];
            String photo_path = photoUpload(Request.Form.Files);
            Event.EventImage = photo_path;
            Event.EventDescription = Request.Form["eventDescription"];
            Event.EventCharges = Request.Form["eventCharges"];



           



            int result = eventDB.OnInsert(Event);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Event Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Event Not Inserted", data = result });
            }
        }


        [HttpPost("updateEvent")]
        public JsonResult updateEvent()
        {
            event_tableEntities Event = new event_tableEntities();

            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    Event.EventImage = photo_path;
                }
                else
                {
                    Event.EventImage = Request.Form["images"];
                }
            }
            else
            {
                Event.EventImage = Request.Form["images"];
            }
            Event.EventIDPK = Int32.Parse(Request.Form["eventIDPK"]);
            Event.EventName = Request.Form["eventName"];
            Event.EventDescription = Request.Form["eventDescription"];
            Event.EventCharges = Request.Form["eventCharges"];

            int result = eventDB.OnUpdate(Event);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Event Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Event Not Updated", data = result });
            }
        }

        [HttpDelete("deleteEvent/{id}")]
        public JsonResult deleteEvent(int id)
        {
            int result = eventDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "Event Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "Event Not Deleted", data = result });
            }
        }
        //faq
        [HttpGet("faqList")]
        public JsonResult faqList()
        {
            List<faq_tableEntities> faq = faqDB.OnGetListdt();
            if (faq.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "faq List Found", data = faq });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "faq List Not Found", data = faq });
            }
        }

        [HttpGet("faqData/{id}")]
        public JsonResult faqData(int id)
        {
            faq_tableEntities faq = faqDB.OnGetData(id);
            if (faq != null)
            {
                return new JsonResult(new { result = "success", message = "faq Data Found", data = faq });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "faq Data Not Found", data = faq });
            }
        }

        [HttpPost("insertfaq")]
        public JsonResult insertfaq(faq_tableEntities faq)
        {
            int result = faqDB.OnInsert(faq);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "faq Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "faq Not Inserted", data = result });
            }
        }

        [HttpPost("updatefaq")]
        public JsonResult updatefaq(faq_tableEntities faq)
        {
            int result = faqDB.OnUpdate(faq);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "faq Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "faq Not Updated", data = result });
            }
        }

        [HttpDelete("deletefaq/{id}")]
        public JsonResult deletefaq(int id)
        {
            int result = faqDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "faq Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "faq Not Deleted", data = result });
            }
        }
        //foodCourt
        [HttpGet("foodCourtList")]
        public JsonResult foodCourtList()
        {
            List<foodCourt_tableEntities> foodCourt = foodCourtDB.OnGetListdt();
            if (foodCourt.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "foodCourt List Found", data = foodCourt });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "foodCourt List Not Found", data = foodCourt });
            }
        }

        [HttpGet("foodCourtData/{id}")]
        public JsonResult foodCourtData(int id)
        {
            foodCourt_tableEntities foodCourt = foodCourtDB.OnGetData(id);
            if (foodCourt != null)
            {
                return new JsonResult(new { result = "success", message = "foodCourt Data Found", data = foodCourt });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "foodCourt Data Not Found", data = foodCourt });
            }
        }

        [HttpPost("insertfoodCourt")]
        public JsonResult insertfoodCourt()
        {
            foodCourt_tableEntities foodCourt = new foodCourt_tableEntities();
            foodCourt.FoodCourtName = Request.Form["foodCourtName"];
            String photo_path = photoUpload(Request.Form.Files);
            foodCourt.FoodCourtImage = photo_path;
            foodCourt.FoodCourtDescription = Request.Form["foodCourtDescription"];
            

            int result = foodCourtDB.OnInsert(foodCourt);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "foodCourt Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "foodCourt Not Inserted", data = result });
            }
        }

        [HttpPost("updatefoodCourt")]
        public JsonResult updatefoodCourt()
        {
            foodCourt_tableEntities foodCourt = new foodCourt_tableEntities();
            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    foodCourt.FoodCourtImage = photo_path;
                }
                else
                {
                    foodCourt.FoodCourtImage = Request.Form["images"];
                }
            }
            else
            {
                foodCourt.FoodCourtImage = Request.Form["images"];
            }
            foodCourt.FoodCourtName = Request.Form["foodCourtName"];
            foodCourt.FoodCourtDescription = Request.Form["foodCourtDescription"];
            foodCourt.FoodCourtIDPK = Int32.Parse(Request.Form["foodCourtIDPK"]);

            int result = foodCourtDB.OnUpdate(foodCourt);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "foodCourt Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "foodCourt Not Updated", data = result });
            }
        }

        [HttpDelete("deletefoodCourt/{id}")]
        public JsonResult deletefoodCourt(int id)
        {
            int result = foodCourtDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "foodCourt Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "foodCourt Not Deleted", data = result });
            }
        }
        //gallery
        [HttpGet("galleryList")]
        public JsonResult galleryList()
        {
            List<gallery_tableEntities> gallery = galleryDB.OnGetListdt();
            if (gallery.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "gallery List Found", data = gallery });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "gallery List Not Found", data = gallery });
            }
        }

        [HttpGet("galleryData/{id}")]
        public JsonResult galleryData(int id)
        {
            gallery_tableEntities gallery = galleryDB.OnGetData(id);
            if (gallery != null)
            {
                return new JsonResult(new { result = "success", message = "gallery Data Found", data = gallery });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "gallery Data Not Found", data = gallery });
            }
        }

        [HttpPost("insertgallery")]
        public JsonResult insertgallery()
        {
            gallery_tableEntities gallery = new gallery_tableEntities();
            String photo_path = photoUpload(Request.Form.Files);
            gallery.GalleryImage = photo_path;
            int result = galleryDB.OnInsert(gallery);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "gallery Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "gallery Not Inserted", data = result });
            }
        }

        [HttpPost("updategallery")]
        public JsonResult updategallery()
        {
            gallery_tableEntities gallery = new gallery_tableEntities();
            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    gallery.GalleryImage = photo_path;
                }
                else
                {
                    gallery.GalleryImage = Request.Form["images"];
                }
            }
            else
            {
                gallery.GalleryImage = Request.Form["images"];
            }
            gallery.GalleryIDPK = Int32.Parse(Request.Form["galleryIDPK"]);

            int result = galleryDB.OnUpdate(gallery);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "gallery Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "gallery Not Updated", data = result });
            }
        }

        [HttpDelete("deletegallery/{id}")]
        public JsonResult deletegallery(int id)
        {
            int result = galleryDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "gallery Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "gallery Not Deleted", data = result });
            }
        }
        //inquiry
        [HttpGet("inquiryList")]
        public JsonResult inquiryList()
        {
            List<inquiry_tableEntities> inquiry = inquiryDB.OnGetListdt();
            if (inquiry.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "inquiry List Found", data = inquiry });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "inquiry List Not Found", data = inquiry });
            }
        }

        [HttpGet("inquiryData/{id}")]
        public JsonResult inquiryData(int id)
        {
            inquiry_tableEntities inquiry = inquiryDB.OnGetData(id);
            if (inquiry != null)
            {
                return new JsonResult(new { result = "success", message = "inquiry Data Found", data = inquiry });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "inquiry Data Not Found", data = inquiry });
            }
        }

        [HttpPost("insertinquiry")]
        public JsonResult insertinquiry(inquiry_tableEntities inquiry)
        {
            inquiry.AddedOn =DateTime.Now.ToString();
            int result = inquiryDB.OnInsert(inquiry);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "inquiry Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "inquiry Not Inserted", data = result });
            }
        }

        [HttpPost("updateinquiry")]
        public JsonResult updateinquiry(inquiry_tableEntities inquiry)
        {
            int result = inquiryDB.OnUpdate(inquiry);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "inquiry Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "inquiry Not Updated", data = result });
            }
        }

        [HttpDelete("deleteinquiry/{id}")]
        public JsonResult deleteinquiry(int id)
        {
            int result = inquiryDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "inquiry Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "inquiry Not Deleted", data = result });
            }
        }
        //offers
        [HttpGet("offersList")]
        public JsonResult offersList()
        {
            List<offers_tableEntities> offers = offersDB.OnGetListdt();
            if (offers.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "offers List Found", data = offers });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "offers List Not Found", data = offers });
            }
        }

        [HttpGet("offersData/{id}")]
        public JsonResult offersData(int id)
        {
            offers_tableEntities offers = offersDB.OnGetData(id);
            if (offers != null)
            {
                return new JsonResult(new { result = "success", message = "offers Data Found", data = offers });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "offers Data Not Found", data = offers });
            }
        }

        [HttpPost("insertoffers")]
        public JsonResult insertoffers()
        {
            offers_tableEntities offers = new offers_tableEntities();
            offers.OffersPromocode = Request.Form["offersPromoCode"];
            String photo_path = photoUpload(Request.Form.Files);
            offers.OffersPhoto = photo_path;
            offers.OffersDescription = Request.Form["offersDescription"];
            int result = offersDB.OnInsert(offers);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "offers Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "offers Not Inserted", data = result });
            }
        }

        [HttpPost("updateoffers")]
        public JsonResult updateoffers()
        {
            offers_tableEntities offers = new offers_tableEntities();
            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    offers.OffersPhoto = photo_path;
                }
                else
                {
                    offers.OffersPhoto = Request.Form["images"];
                }
            }
            else
            {
                offers.OffersPhoto = Request.Form["images"];
            }
            offers.OffersIDPK = Int32.Parse(Request.Form["offersIDPK"]);
            offers.OffersPromocode = Request.Form["offersPromoCode"];
            offers.OffersDescription = Request.Form["offersDescription"];
            int result = offersDB.OnUpdate(offers);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "offers Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "offers Not Updated", data = result });
            }
        }

        [HttpDelete("deleteoffers/{id}")]
        public JsonResult deleteoffers(int id)
        {
            int result = offersDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "offers Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "offers Not Deleted", data = result });
            }
        }
        //package
        [HttpGet("packageList")]
        public JsonResult packageList()
        {
            List<package_tableEntities> package = packageDB.OnGetListdt();
            if (package.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "package List Found", data = package });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "package List Not Found", data = package });
            }
        }

        [HttpGet("packageData/{id}")]
        public JsonResult packageData(int id)
        {
            package_tableEntities package = packageDB.OnGetData(id);
            if (package != null)
            {
                return new JsonResult(new { result = "success", message = "package Data Found", data = package });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "package Data Not Found", data = package });
            }
        }

        [HttpPost("insertpackage")]
        public JsonResult insertpackage()
        {
            package_tableEntities package = new package_tableEntities();
            package.PackageName = Request.Form["packageName"];
            String photo_path = photoUpload(Request.Form.Files);
            package.PackageImage = photo_path;
            package.PackageDescription = Request.Form["packageDescription"];
            package.PackageCharges = Request.Form["packageCharges"];


            int result = packageDB.OnInsert(package);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "package Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "package Not Inserted", data = result });
            }
        }

        [HttpPost("updatepackage")]
        public JsonResult updatepackage()
        {
            package_tableEntities package = new package_tableEntities();
            if (Request.Form.Files.Count != 0)
            {

                if (Request.Form.Files[0].Length > 0)
                {
                    String photo_path = photoUpload(Request.Form.Files);
                    package.PackageImage = photo_path;
                }
                else
                {
                    package.PackageImage = Request.Form["images"];
                }
            }
            else
            {
                package.PackageImage = Request.Form["images"];
            }
            package.PackageIDPK = Int32.Parse(Request.Form["packageIDPK"]);
            package.PackageName = Request.Form["packageName"];
            package.PackageDescription = Request.Form["packageDescription"];
            package.PackageCharges = Request.Form["packageCharges"];
            int result = packageDB.OnUpdate(package);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "package Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "package Not Updated", data = result });
            }
        }

        [HttpDelete("deletepackage/{id}")]
        public JsonResult deletepackage(int id)
        {
            int result = packageDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "package Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "package Not Deleted", data = result });
            }
        }
        
        //review
        [HttpGet("reviewList")]
        public JsonResult reviewList()
        {
            List<review_tableEntities> review = reviewDB.OnGetListdt();
            if (review.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "review List Found", data = review });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "review List Not Found", data = review });
            }
        }

        [HttpGet("reviewData/{id}")]
        public JsonResult reviewData(int id)
        {
            review_tableEntities review = reviewDB.OnGetData(id);
            if (review != null)
            {
                return new JsonResult(new { result = "success", message = "review Data Found", data = review });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "review Data Not Found", data = review });
            }
        }

        [HttpPost("insertreview")]
        public JsonResult insertreview(review_tableEntities review)
        {
            int result = reviewDB.OnInsert(review);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "review Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "review Not Inserted", data = result });
            }
        }

        [HttpPost("updatereview")]
        public JsonResult updatereview(review_tableEntities review)
        {
            int result = reviewDB.OnUpdate(review);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "review Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "review Not Updated", data = result });
            }
        }

        [HttpDelete("deletereview/{id}")]
        public JsonResult deletereview(int id)
        {
            int result = reviewDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "review Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "review Not Deleted", data = result });
            }
        }
        //user
        [HttpGet("userList")]
        public JsonResult userList()
        {
            List<user_tableEntities> user = userDB.OnGetListdt();
            if (user.Count != 0)
            {
                return new JsonResult(new { result = "success", message = "user List Found", data = user });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "user List Not Found", data = user });
            }
        }

        [HttpGet("userData/{id}")]
        public JsonResult userData(int id)
        {
            user_tableEntities user = userDB.OnGetData(id);
            if (user != null)
            {
                return new JsonResult(new { result = "success", message = "user Data Found", data = user });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "user Data Not Found", data = user });
            }
        }

        [HttpPost("insertuser")]
        public JsonResult insertuser(user_tableEntities user)
        {
            int result = userDB.OnInsert(user);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "user Inserted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "user Not Inserted", data = result });
            }
        }

        [HttpPost("updateuser")]
        public JsonResult updateuser(user_tableEntities user)
        {
            int result = userDB.OnUpdate(user);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "user Updated", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "user Not Updated", data = result });
            }
        }

        [HttpDelete("deleteuser/{id}")]
        public JsonResult deleteuser(int id)
        {
            int result = userDB.OnDelete(id);
            if (result == 1)
            {
                return new JsonResult(new { result = "success", message = "user Deleted", data = result });
            }
            else
            {
                return new JsonResult(new { result = "failure", message = "user Not Deleted", data = result });
            }
        }


        private String photoUpload(IFormFileCollection Files)
        {
            Random _random = new Random();
            var file = Files[0];
            var folderName = Path.Combine("uploads", "images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            var fileName = "IMG_" + _random.Next(1, 999) + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fullPath = Path.Combine(pathToSave, fileName);
            var dbPath = Path.Combine(folderName, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return dbPath;

        }
    }
}
