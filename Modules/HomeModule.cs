using Nancy;
using System;
using System.Collections.Generic;
using HairSalon;

namespace HairSalon
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ =>{
        List<Stylist> allStylist = Stylist.GetAll();
        return View["index.cshtml", allStylist];
      };

      Get["/stylist/form"] = _ => View["stylist-form.cshtml"];

      Post["/stylist/new"] = _ => {
        Stylist newStylist = new Stylist(Request.Form["stylist-name"], Request.Form["stylist-age"], Request.Form["stylist-bio"]);
        newStylist.Save();
        List<Client> stylistClients = newStylist.GetClients();
        Dictionary<string, object> model = new Dictionary<string, object>(){{"stylist", newStylist}, {"clients", stylistClients}};
        return View["stylist.cshtml", model];
      };
    }
  }
}
