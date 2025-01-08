using System;
using Xamarin.Forms;

namespace Для_курсача
{
    public partial class App : Application //Класс App является точкой входа для приложения. Он определяет общие настройки и поведение приложения
    {
        public App() //Вызывается при запуске приложения 
        {
            InitializeComponent();

            // Указываем, что WelcomePage будет главной страницей приложения
            MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart() //Вызывается при запуске приложения
        {
        }

        protected override void OnSleep() //Вызывается, когда приложение сворчавивается 
        {
        }

        protected override void OnResume() //Вызывается, когда приложение возвращается из состояния свёрнутости
        {
        }
    }
}