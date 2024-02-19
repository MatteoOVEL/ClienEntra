using ClienEntra.Models;
using ClienEntra.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienEntra.ViewModels
{
    public class AjoutMusiqueViewModel : ObservableObject
    {
        private Musique musique;
        public Musique Musique
        {
            get { return musique; }
            set
            {
                musique = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Chanteur> chanteur;

        public ObservableCollection<Chanteur> Chanteur
        {
            get { return chanteur; }
            set
            {
                chanteur = value;
                OnPropertyChanged();
            }
        }

        private  Chanteur chanteurSelectionnee;
        public Chanteur ChanteurSelectionnee
        {
            get { return chanteurSelectionnee; }
            set
            {
                chanteurSelectionnee = value;
                OnPropertyChanged();
            }
        }

        public IRelayCommand BtnSearch { get; }
        public AjoutMusiqueViewModel()
        {
            Musique=new Musique();
            this.GetDataOnLoadAsync();
            BtnSearch = new RelayCommand(ActionAddMusique);

        }



        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("http://localhost:7144/");
            List<Chanteur> result = await service.GetSerieAsync("Chanteurs");
            //if (result == null)
            //{
            //    MessageAsync("API non disponible", "Erreur");
            //}
           
                Chanteur = new ObservableCollection<Chanteur>(result);
            


        }

        public async void ActionAddMusique()
        {
            bool res;
            Musique=new Musique()
            {
                
                Titre = Musique.Titre,
                Genre = Musique.Genre,
                Chanteur = ChanteurSelectionnee
            };
            WSService service = new WSService("https://localhost:7144/api/");
            res = await service.PostSerieAsync(Musique);
            if (!res)
            {
                //ContentDialog noApi = new ContentDialog
                //{
                //    Title = "marche pas",
                //    Content = "marche pas",
                //    CloseButtonText = "OK"

                //};
                //noApi.XamlRoot = App.MainRoot.XamlRoot;

                //ContentDialogResult result = await noApi.ShowAsync();
            }
        }

    }
}
