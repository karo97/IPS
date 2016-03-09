using IPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace IPS.Controllers
{
    public class ContactController:SurfaceController
    {
        public ActionResult ShowForm(int id)
        {
            return PartialView("ContactForm", new ContactModels()); 
        }

        public ActionResult HandleFormPost(ContactModels model)
        {
            var PageId = 0;
            var siteRoot = CurrentPage.AncestorOrSelf(1);
            var NodeChildren = siteRoot.Descendants("Kontakt");
            foreach (var VARIABLE in NodeChildren)
            {
                PageId = VARIABLE.Id;
            }
            var newComment = Services.ContentService.CreateContent(model.Name + " - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"), PageId, "ContactFormula");

            newComment.SetValue("name", model.Email);
            newComment.SetValue("title", model.Title);
            newComment.SetValue("email", model.Email);
            newComment.SetValue("message", model.Message);
            Services.ContentService.SaveAndPublishWithStatus(newComment);
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            return RedirectToCurrentUmbracoPage();
        }
    }
}