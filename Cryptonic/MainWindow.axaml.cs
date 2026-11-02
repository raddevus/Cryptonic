using Avalonia.Controls;
using AppHelpers;
using Cryptonic.Models;
using Avalonia.Interactivity;
using System;
using Avalonia;
using Avalonia.Input.Platform; // for IClipboard

namespace Cryptonic;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

        public void SetHidePattern(object? sender, RoutedEventArgs e){
      Console.WriteLine("Setting Hide Pattern bool");
      PwdGrid.IsPatternHidden = (sender as CheckBox)?.IsChecked ?? false;
      System.Console.WriteLine($"isPatternHidden: {PwdGrid.IsPatternHidden}");
      PwdGrid.ForceRender();
    }

      public void ClearHandler(object? sender, RoutedEventArgs e){
      Console.WriteLine("Clear the grid.");
      PwdGrid.Reset();
      HidePatternCheckBox.IsChecked = false;
    }
   private async void PasswordTextChanged(object? sender, RoutedEventArgs e){
         try{
            var topLevel = TopLevel.GetTopLevel((Control)sender!);

             if (topLevel?.Clipboard is { } clipboard)
             {
                 await clipboard.SetTextAsync(PwdTextBox?.Text ?? string.Empty);
             }
         }
         catch (Exception ex){
            Console.WriteLine("Couldn't copy to clipboard.");
         }
   }

}
