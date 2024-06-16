using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using DatabaseLayer.Database.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MsBox.Avalonia;
using Newtonsoft.Json;
using QRCoder;
using ShiftManager.Classes.APIManagement;
using ShiftManager.Helpers;

namespace ShiftManager
{
    
    public partial class MainWindow : Window
    {

        static CancellationTokenSource timerCtsSource = new CancellationTokenSource();
        CancellationToken timerCts = timerCtsSource.Token;
        private bool isShiftOpen = false;
        public MainWindow()
        {
            InitializeComponent();
            DownloadTradePoint();
            
        }

        private void DownloadTradePoint()
        {
            if (ICurrentData.LoginedEmployee == null)
            {
                MessageBoxManager.GetMessageBoxStandard("Ошибка", "У пользователя нет точки доступа!").ShowAsync();
                return;
            }

            TradePointName.Text = $"Привязанная торговая точка: {ICurrentData.LoginedEmployee.Access.TradePoint.PointName}";

        }
        
        private void HideBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseBtn_OnClick(object? sender, RoutedEventArgs e)
        {
            if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopApp)
            {
                desktopApp.Shutdown();
            }
            else if (Application.Current?.ApplicationLifetime is ISingleViewApplicationLifetime viewApp)
            {
                viewApp.MainView = null;
            }
        }
        
        private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            {
                BeginMoveDrag(e);
            }
        }

        private void UpdateTimer()
        {

            int seconds = 0;
            
            Task.Run(() =>
            {
                

                while (true)
                {
                    
                    if (timerCts.IsCancellationRequested)
                    {
                        MessageBoxManager.GetMessageBoxStandard("Успешно", "Смена закрыта").ShowAsync();
                        return;
                    }

                    seconds += 1;
                    Dispatcher.UIThread.Invoke((Action)delegate
                    {
                        OpenedShiftTimer.Text = $"Смена открыта уже {seconds} сек.";
                    });
                    
                    Thread.Sleep(1000);
                }
            });
        }
        
        
        
        private void Button_OnClick(object? sender, RoutedEventArgs e)
        {

          
            using (var client = IAPIManager.GetHttpClient())
            {
                try
                {
                    var apiResponse = client.PostAsJsonAsync("Shifts/shiftInterruct",
                        ICurrentData.LoginedEmployee.Access.TradePoint);
                    var resp = apiResponse.Result.Content.ReadAsStringAsync().Result;
                    if (resp != "Смена успешно закрыта.")
                    {
                        try
                        {
                            var shift = JsonConvert.DeserializeObject<OpenedShift>(resp);
                            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
                            QRCodeData data = qrCodeGenerator.CreateQrCode($"{shift.Id}", QRCodeGenerator.ECCLevel.M);
                            using (var ms = new MemoryStream(new PngByteQRCode(data).GetGraphic((20))))
                            {
                                var bmp = new Bitmap(ms);
                                QRCodeImageUI.Source = bmp;
                            }

                        }
                        catch(Exception exception)
                        {
                            MessageBoxManager.GetMessageBoxStandard("asd", exception.Message).ShowAsync();
                            return;
                        }
                    }
                    
                    
                    
                }
                catch (Exception ex)
                {
                    MessageBoxManager.GetMessageBoxStandard("Ошибка", ex.Message).ShowAsync();
                    return;
                }
            }
            
            if (isShiftOpen == false)
            {
                isShiftOpen = true;
                timerCtsSource.TryReset();
                UpdateTimer();
                ShiftInterractorBtn.Content = "Закрыть смену";
            }
            else
            {
                isShiftOpen = false;
                timerCtsSource.Cancel();
                QRCodeImageUI.Source = null;
                ShiftInterractorBtn.Content = "Открыть смену";
            }
        }
    }
}