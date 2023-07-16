﻿using Maui.Controls.UserDialogs;

using Microsoft.Extensions.Logging;

namespace Sample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseUserDialogs(() =>
                {
                    var fontFamily = "OpenSans-Semibold.ttf";
                    AlertConfig.DefaultFontFamily = fontFamily;
                    ConfirmConfig.DefaultFontFamily = fontFamily;
                    ActionSheetConfig.DefaultFontFamily = fontFamily;
                    ToastConfig.DefaultFontFamily = fontFamily;
                    SnackbarConfig.DefaultFontFamily = fontFamily;
                    HudDialogConfig.DefaultFontFamily = fontFamily;
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}