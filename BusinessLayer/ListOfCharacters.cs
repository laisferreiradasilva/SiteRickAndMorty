using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessLayer
{
    public class ListOfCharacters
    {
        public class ViewModel
        {
            public ViewModel()
            {
                Status = new[]
                {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "Alive", Text = "Alive" },
                    new SelectListItem { Value = "Dead", Text = "Dead" },
                    new SelectListItem { Value = "Unknown", Text = "Unknown" },
                };

                Gender = new[]
                {
                    new SelectListItem { Value = "", Text = "" },
                    new SelectListItem { Value = "Female", Text = "Female" },
                    new SelectListItem { Value = "Male", Text = "Male" },
                    new SelectListItem { Value = "Genderless", Text = "Genderless" },
                    new SelectListItem { Value = "Unknown", Text = "Unknown" }
                };
            }
            public string Message { get; set; }
            public string SearchName { get; set; }
            public List<ServiceLayer.ListOfCharacters.Character> Characters { get; set; }
            public ServiceLayer.ListOfCharacters.Character Character { get; set; }
            public string SearchGender { get; set; }
            public string SearchStatus { get; set; }
            public SelectListItem[] Status { get; set; }
            public SelectListItem[] Gender { get; set; }
            public string SearchNameDetail { get; set; }
        }
        public void SearchName(ViewModel viewModel)
        {
            ServiceLayer.ListOfCharacters listCharacters = new ServiceLayer.ListOfCharacters();

            if (viewModel.Characters == null)
            {
                viewModel.Characters = listCharacters.GetAll();
            }

            if (String.IsNullOrEmpty(viewModel.SearchName) == false)
            {
                viewModel.Characters = viewModel.Characters.Where(a => a.Name.ToLower().Contains(viewModel.SearchName.ToLower())).ToList();
            }
        }
        public void SearchStatus(ViewModel viewModel)
        {
            ServiceLayer.ListOfCharacters listCharacters = new ServiceLayer.ListOfCharacters();

            if (viewModel.Characters == null)
            {
                viewModel.Characters = listCharacters.GetAll();
            }

            if (String.IsNullOrEmpty(viewModel.SearchStatus) == false)
            {
                viewModel.Characters = viewModel.Characters.Where(a => a.Status.ToLower() == viewModel.SearchStatus.ToLower()).ToList();
            }
        }
        public void SearchGender(ViewModel viewModel)
        {
            ServiceLayer.ListOfCharacters listCharacters = new ServiceLayer.ListOfCharacters();

            if (viewModel.Characters == null)
            {
                viewModel.Characters = listCharacters.GetAll();
            }

            if (String.IsNullOrEmpty(viewModel.SearchGender) == false)
            {
                viewModel.Characters = viewModel.Characters.Where(a => a.Gender.ToLower() == viewModel.SearchGender.ToLower()).ToList();
            }
        }

        public void GetDetail(ViewModel viewModel)
        {
            ServiceLayer.ListOfCharacters listCharacters = new ServiceLayer.ListOfCharacters();
            List<ServiceLayer.ListOfCharacters.Character> characters = listCharacters.GetAll();
            if (string.IsNullOrWhiteSpace(viewModel.SearchNameDetail) == false)
            {
                viewModel.Character = characters.FirstOrDefault(d => d.Name.ToLower() == viewModel.SearchNameDetail.ToLower());             
            }
        }
    }
}
