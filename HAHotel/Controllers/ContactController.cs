using System.Web.Mvc;
using HAHotel.Models;
using HAHotel.Repository;

namespace HAHotel.Controllers
{
    public class ContactController: BaseController
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(ILayoutRepository layoutRepository, IContactRepository contactRepository):base(layoutRepository)
        {
            _contactRepository = contactRepository;
        }

        public ActionResult Index()
        {
            var model = LayoutRepository.LoadFooterDefaul();
            SetCurrentMenu();
            return View(model);
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult Send(Contact contact)
        {
            var model = LayoutRepository.LoadFooterDefaul();
            SetCurrentMenu();

            if (contact == null)
            {
                SetFailedNotification("Có lỗi xảy ra. Vui lòng thử lại");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    foreach(var error in item.Errors)
                    {
                        SetFailedNotification(error.ErrorMessage);
                    }
                }

                return RedirectToAction("Index");
            }

            var message = contact.Id > 0 ? "Cập nhật" : "Thêm";
            if (_contactRepository.Save(contact))
            {
                SetSuccessNotification($"{message} liên hệ thành công");
            }
            else
            {
                SetFailedNotification("Đã có lỗi xảy ra. Xin vui lòng thử lại");
            }

            return RedirectToAction("Index");
        }
    }
}