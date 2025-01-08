using System;
using Xamarin.Forms;

namespace Для_курсача
{
    public class WelcomePage : ContentPage 
    {
        public WelcomePage() //Первая страница, которая отображается при запуске приложения
        {
            Title = "Добро пожаловать в Крылья Птицы";
            BackgroundColor = Color.LightSkyBlue; // Синий фон

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =
            {
                CreateNavigationButton("О нас", () => new AboutPage()), //Страница с информацией об аэроклубе
                CreateNavigationButton("Каталог", () => new CatalogPage()), //Страница каталога услуг
                CreateNavigationButton("Личный кабинет", () => new ProfilePage()), //Страница личного кабинета пользователя 
                CreateNavigationButton("Забронировать", () => new BookingPage()) //Страница для бронирования 
            }
            };

 
        }

        private Xamarin.Forms.Button CreateNavigationButton(string text, Func<Page> pageFactory)
        {
            var button = new Xamarin.Forms.Button
            {
                Text = text,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10)
            };
            button.Clicked += (s, e) => Navigation.PushAsync(pageFactory());
            return button;
        }

        private async void NavigateToCatalog()
        {
            await Navigation.PushAsync(new CatalogPage());
        }
    }


}


public class AboutPage : ContentPage
    {
        public AboutPage()
        {
            Title = "О нас";
            BackgroundColor = Color.LightSkyBlue; // Синий фон

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    new Label
                    {
                        Text = "Аэроклуб \"Крылья Птицы\" предлагает уникальные возможности для обучения пилотированию и полётам на современных самолётах.",
                        FontSize = 18,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    },
                    new Label
                    {
                        Text = "Наши самолёты:",
                        FontSize = 16,
                        Margin = new Thickness(0, 10)
                    },
                    new ListView
                    {
                        ItemsSource = new[] { "Cessna 172", "Piper PA-28", "Diamond DA40", "Cirrus SR22" },
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
    }
}


public class CatalogPage : ContentPage
{
    public CatalogPage()
    {
        Title = "Каталог";
        BackgroundColor = Color.LightSkyBlue; // Синий фон

        // Данные о пакетах
        var packages = new[]
        {
            new { Name = "Ознакомительный полёт", Details = "Длительность: 15 минут\nВидеосъёмка: включена\nФотосессия: на земле у самолёта\nМаршрут: вокруг аэродрома\nСтоимость: 5,000 руб." },
            new { Name = "Ночной полёт", Details = "Длительность: 30 минут\nВидеосъёмка: включена\nФотосессия: в кабине самолёта\nМаршрут: индивидуальный\nСтоимость: 10,000 руб." },
            new { Name = "Экскурсионный полёт", Details = "Длительность: 45 минут\nВидеосъёмка: включена\nФотосессия: на фоне самолёта\nМаршрут: туристический маршрут\nСтоимость: 15,000 руб." },
            new { Name = "Групповой полёт", Details = "Длительность: 1 час\nВидеосъёмка: включена\nФотосессия: с группой на фоне самолёта\nМаршрут: по выбору\nСтоимость: 20,000 руб." }
        };

        var carousel = new StackLayout
        {
            Padding = new Thickness(10),
            Spacing = 20
        };

        foreach (var package in packages)
        {
            var frame = new Frame
            {
                BorderColor = Color.Gray,
                CornerRadius = 10,
                Padding = 10,
                Content = new StackLayout
                {
                    Children =
                    {
                        new Xamarin.Forms.Label
                        {
                            Text = package.Name,
                            FontSize = 16,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        new Xamarin.Forms.Button
                        {
                            Text = "Узнать подробнее",
                            Command = new Command(() => DisplayAlert("Детали", package.Details, "ОК"))
                        }
                    }
                }
            };

            carousel.Children.Add(frame);
        }

        Content = new ScrollView { Content = carousel };
    }
}


public class ProfilePage : ContentPage
{
    private Entry nameEntry;
    private Entry surnameEntry;
    private Entry phoneEntry;
    private DatePicker birthDatePicker;

    // Статические свойства для сохранения данных
    private static string SavedName = string.Empty;
    private static string SavedSurname = string.Empty;
    private static string SavedPhone = string.Empty;
    private static DateTime SavedBirthDate = DateTime.Today;

    public ProfilePage()
    {
        Title = "Личный кабинет";
        BackgroundColor = Color.LightSkyBlue; // Синий фон

        nameEntry = new Entry { Placeholder = "Введите ваше имя", Text = SavedName };
        surnameEntry = new Entry { Placeholder = "Введите вашу фамилию", Text = SavedSurname };
        phoneEntry = new Entry { Placeholder = "Введите номер телефона", Keyboard = Keyboard.Telephone, Text = SavedPhone };
        birthDatePicker = new DatePicker { Date = SavedBirthDate };

        var saveButton = new Button
        {
            Text = "Сохранить",
            Command = new Command(SaveProfile)
        };

        Content = new StackLayout
        {
            Padding = new Thickness(10),
            Children =
            {
                new Label { Text = "Имя:", FontSize = 16 },
                nameEntry,
                new Label { Text = "Фамилия:", FontSize = 16 },
                surnameEntry,
                new Label { Text = "Номер телефона:", FontSize = 16 },
                phoneEntry,
                new Label { Text = "Год рождения:", FontSize = 16 },
                birthDatePicker,
                saveButton
            }
        };
    }

    private async void SaveProfile()
    {
        // Сохраняем данные в статические свойства
        SavedName = nameEntry.Text;
        SavedSurname = surnameEntry.Text;
        SavedPhone = phoneEntry.Text;
        SavedBirthDate = birthDatePicker.Date;

        await DisplayAlert("Ваши данные сохранены", "© 2025 ООО КРЫЛЬЯ ПТИЦЫ. Все права защищены", "ОК");
    }
}


public class BookingPage : ContentPage
    {
        public BookingPage()
        {
            Title = "Бронирование";
            BackgroundColor = Color.LightSkyBlue; // Синий фон

            Content = new StackLayout
            {
                Padding = new Thickness(10),
                Children =
                {
                    new Label { Text = "Фамилия и Имя:", FontSize = 16 },
                    new Entry { Placeholder = "Введите фамилию и имя" },
                    new Label { Text = "Дата полёта:", FontSize = 16 },
                    new DatePicker(),
                    new Label { Text = "Количество пассажиров:", FontSize = 16 },
                    new Entry { Placeholder = "Введите количество", Keyboard = Keyboard.Numeric },
                    new Label { Text = "Вид полёта:", FontSize = 16 },
                    new Picker
                    {
                        ItemsSource = new[] { "Ознакомительный", "Ночной", "Экскурсионный", "Групповой" }
                    },
                    new Button
                    {
                        Text = "Забронировать",
                        Command = new Command(() => DisplayAlert("Бронирование успешно оформлено!", "© 2025 ООО КРЫЛЬЯ ПТИЦЫ. Все права защищены", "ОК"))
                    }
                }
            };
        }
    }

