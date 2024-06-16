using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DatabaseLayer.Database.Models;
using MsBox.Avalonia;
using Newtonsoft.Json;
using ShiftManager.Helpers;
using TimeControllerAPI.Classes;
using Tmds.DBus.Protocol;

namespace ShiftManager.Views;

public partial class AuthorizationPage : Window
{
    public AuthorizationPage()
    {
        InitializeComponent();
    }

    private void AuthorizeBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        using (var client = IAPIManager.GetHttpClient())
        {

            try
            {
                var response = client.PostAsJsonAsync("Authentication/signin",
                    new SignInRequest(LoginTextBox.Text, PasswordTextBox.Text)).Result;
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessageBoxManager.GetMessageBoxStandard("Error", "Введены неверные данные");
                    return;
                }

                try
                {
                    var loginedEmployee =
                        JsonConvert.DeserializeObject<Employee>(response.Content.ReadAsStringAsync().Result);
                    ICurrentData.LoginedEmployee = loginedEmployee;
                    new MainWindow().Show();
                    this.Hide();
                }
                catch(Exception exception)
                {
                    MessageBoxManager.GetMessageBoxStandard("Error", exception.Message).ShowAsync();
                }
            }
            catch (Exception exception)
            {
                MessageBoxManager.GetMessageBoxStandard("Error", $"{exception.Message}").ShowAsync();
            }
        }
    }
}