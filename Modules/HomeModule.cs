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

      Get["/stylist/{id}"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.id);
        List<Client> stylistClients = currentStylist.GetClients();
        Dictionary<string, object> model = new Dictionary<string, object>(){{"stylist", currentStylist}, {"clients", stylistClients}};
        return View["stylist.cshtml", model];
      };

      Post["/stylist/{id}/client/new"] = parameters => {
        Client newClient = new Client(Request.Form["client-name"], parameters.id);
        newClient.Save();
        Stylist currentStylist = Stylist.Find(parameters.id);
        List<Client> stylistClients = currentStylist.GetClients();
        Dictionary<string, object> model = new Dictionary<string, object>(){{"stylist", currentStylist}, {"clients", stylistClients}};
        return View["stylist.cshtml", model];
      };

      Get["/stylist/{stylistId}/client/{id}/edit"] = parameters => {
        Stylist currentStylist = Stylist.Find(parameters.stylistId);
        Client currentClient = Client.Find(parameters.id);
        Dictionary<string, object> model = new Dictionary<string, object>(){{"stylist", currentStylist}, {"client", currentClient}};
        return View["client_edit.cshtml", model];
      };

      Patch["/stylist/{stylistId}/client/{id}/edited"] = parameters => {
        Client currentClient = Client.Find(parameters.id);
        currentClient.Update(Request.Form["new-client-name"]);
        Stylist currentStylist = Stylist.Find(parameters.StylistId);
        List<Client> stylistClients = currentStylist.GetClients();
        Dictionary<string, object> model = new Dictionary<string, object>(){{"stylist", currentStylist}, {"clients", stylistClients}};
        return View["stylist.cshtml", model];
      };

    }
  }
}
