﻿using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor;
using System;

namespace BlazorApp30.Components.Checkbox
{
    public class CheckboxBase : BaseComponent
    {
        [Parameter] protected string Label { get; set; }
        [Parameter] protected bool Checked { get; set; }
        [Parameter] protected bool Inline { get; set; }
        [Parameter] protected Action<bool> CheckedChanged { get; set; }
        [Parameter] protected CheckboxSize Size { get; set; } = CheckboxSize.REGULAR;

        protected string CheckboxId = Guid.NewGuid().ToString().Replace("-", "");

        protected void HandleChanged(UIChangeEventArgs a)
        {
            Console.WriteLine("cha");
            Checked = (bool)a.Value;
            CheckedChanged?.Invoke(Checked);
        }

        protected void HandleKeyPress(UIKeyboardEventArgs args)
        {
            if (args.Key == " " || args.Key == "Enter")
            {
                Checked = !Checked;
                CheckedChanged?.Invoke(Checked);
            }
        }
    }
}
