﻿using Foundation;

using Microsoft.Maui.Platform;

using UIKit;

namespace Controls.UserDialogs.Maui;

public class AlertBuilder
{
    protected AlertConfig Config { get; }

    public AlertBuilder(AlertConfig config)
    {
        Config = config;
    }

    public virtual UIAlertController Build()
    {
        var alert = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);

        alert.AddAction(GetOkAction());

        if (Config.Title is not null)
        {
            alert.SetValueForKey(GetTitle(), new NSString("attributedTitle"));
        }

        if (Config.Message is not null)
        {
            alert.SetValueForKey(GetMessage(), new NSString("attributedMessage"));
        }

        if (Config.UserInterfaceStyle is not null)
        {
            alert.OverrideUserInterfaceStyle = Config.UserInterfaceStyle.Value.ToNative();
        }

        return alert;
    }

    protected virtual NSAttributedString GetTitle()
    {
        UIFont titleFont = null;
        if (Config.TitleFontFamily is not null)
        {
            titleFont = UIFont.FromName(Config.TitleFontFamily, Config.TitleFontSize);
        }
        titleFont ??= UIFont.SystemFontOfSize(Config.TitleFontSize, UIFontWeight.Bold);

        var attributedString = new NSMutableAttributedString(Config.Title, titleFont, Config.TitleColor?.ToPlatform());

        return attributedString;
    }

    protected virtual NSAttributedString GetMessage()
    {
        UIFont messageFont = null;
        if (Config.MessageFontFamily is not null)
        {
            messageFont = UIFont.FromName(Config.MessageFontFamily, Config.MessageFontSize);
        }
        messageFont ??= UIFont.SystemFontOfSize(Config.MessageFontSize);

        var attributedString = new NSMutableAttributedString(Config.Message, messageFont, Config.MessageColor?.ToPlatform());

        return attributedString;
    }

    protected virtual UIAlertAction GetOkAction()
    {
        var action = UIAlertAction.Create(Config.OkText, UIAlertActionStyle.Default, x => Config.Action?.Invoke());

        if (Config.PositiveButtonTextColor is not null)
        {
            action.SetValueForKey(Config.PositiveButtonTextColor.ToPlatform(), new NSString("titleTextColor"));
        }

        return action;
    }
}