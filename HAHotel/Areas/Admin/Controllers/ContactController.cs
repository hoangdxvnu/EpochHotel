using HAHotel.Areas.Base;
using HAHotel.Models;
using HAHotel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HAHotel.Areas.Admin.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ActionResult Index()
        {
            var model = _contactRepository.GetListContact(new RoomTypeRequest
            {
                PageIndex = PageIndex,
                PageSize = 2
            });
            model.PageSize = 2;
            model.CurrentPage = PageIndex;
            model.BaseUrl = Url.Action("Index", "Contact", new { Area = "Admin" });

            SetPageTitle("Quản lý liên hệ");

            return View(model);
        }

        public ActionResult Edit()
        {
            if (ItemId > 0)
            {
                var model = _contactRepository.GetById(ItemId);
                SetPageTitle("Sửa liên hệ");

                return View(model);
            }

            SetPageTitle("Tạo mới liên hệ");

            return View(new Contact());
        }

        [HttpPost, ValidateInput(true)]
        public ActionResult Edit(Contact contact)
        {
            if (contact == null)
            {
                SetFailedNotification("Có lỗi xảy ra. Vui lòng thử lại");
                return RedirectToAction("Index");
            }

            if (!ModelState.IsValid)
            {
                foreach (var item in ModelState.Values)
                {
                    SetFailedNotification(item.Value.ToString());
                }
                if (ItemId > 0)
                {
                    SetPageTitle("Sửa liên hệ");
                }
                else
                {
                    SetPageTitle("Tạo mới liên hệ");
                }

                return View(contact);
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

        public ActionResult Delete()
        {
            if (ItemId < 0)
            {
                return RedirectToAction("Index");
            }

            _contactRepository.Delete(ItemId);
            SetSuccessNotification("Xóa liên hệ thành công");

            return RedirectToAction("Index");
        }
    }
}