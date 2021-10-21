using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YHmer.Pages.Registration
{
    public class OptionsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Selection { get; set; }

        public void OnGet()
        {

        }

       public ActionResult OnPost()
       {
            if(Request.Form["Student"] == "Student")
            {
                
                return RedirectToPage("/Registration/Registration", new { selection = Request.Form["Student"] });
            }
            else if(Request.Form["F�retag"] == "F�retag")
            {
                return RedirectToPage("/Registration/Registration", new { selection = Request.Form["F�retag"] });
            }
            else if(Request.Form["Anordnare"] == "Anordnare")
            {
                return RedirectToPage("/Registration/Registration", new { selection = Request.Form["Anordnare"] });
            }
            return Page();
       }

    }
}
