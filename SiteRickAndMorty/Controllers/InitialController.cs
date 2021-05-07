using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteRickAndMorty.Controllers
{
    public class InitialController : Controller
    {
        // GET: Initial
        public ActionResult ListOfCharacters()
        {
            BusinessLayer.ListOfCharacters.ViewModel viewModel = new BusinessLayer.ListOfCharacters.ViewModel();
            BusinessLayer.ListOfCharacters listCharacters = new BusinessLayer.ListOfCharacters();
            listCharacters.SearchName(viewModel);

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult ListOfCharacters(BusinessLayer.ListOfCharacters.ViewModel viewModel)
        {
            BusinessLayer.ListOfCharacters listCharacters = new BusinessLayer.ListOfCharacters();

            listCharacters.SearchName(viewModel);
            listCharacters.SearchStatus(viewModel);
            listCharacters.SearchGender(viewModel);

            return View(viewModel);
        }
        public ActionResult CharacterDetails(BusinessLayer.ListOfCharacters.ViewModel viewModel)
        {
            BusinessLayer.ListOfCharacters listCharacters = new BusinessLayer.ListOfCharacters();
            listCharacters.GetDetail(viewModel);
            return View(viewModel);
        }
        public ActionResult CharacterEpisodes()
        {
            return View();
        }
    }
}