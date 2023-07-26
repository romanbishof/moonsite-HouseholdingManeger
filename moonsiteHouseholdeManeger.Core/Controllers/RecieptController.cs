using moonsiteHouseholdeManeger.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace moonsiteHouseholdeManeger.Core.Controllers
{
    //all operations regarding reciept form
    public class RecieptController: SurfaceController
    {
        public ActionResult RenderRecieptForm()
        {
            var vm = new RecieptFormViewModel();

            return PartialView("~/Views/Partials/RecieptForm.cshtml", vm);
        }

        [HttpPost]
        public ActionResult HandleRecieptForm(RecieptFormViewModel vm)
        {
            return null;
        }
    }
}
