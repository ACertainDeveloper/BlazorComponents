﻿using Blazor.Extensions;
using Blazor.Fluxor;
using BlazorApp.Domain;
using BlazorApp.Services;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using RPedretti.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class MainLayoutBase : BlazorLayoutComponent, IDisposable
    {
        [Inject] protected DownloadManager DownloadManager { get; set; }
        [Inject] protected IStore Store { get; set; }

        protected List<string> GuestNames = new List<string>();
        protected ObservableCollection<DownloadResult> AvailableDowloads = new ObservableCollection<DownloadResult>();

        protected override Task OnInitAsync()
        {
            DownloadManager.NewDownloadAvailabe += ShowDownloads;
            return base.OnInitAsync();
        }

        private void ShowDownloads(object sender, NewDownloadAvailableArgs e)
        {
            var result = e.DownloadResult;
            result.Description = $"{result.Url} ({result.Id})";
            AvailableDowloads.Add(result);
        }

        public void Dispose()
        {
            DownloadManager.NewDownloadAvailabe -= ShowDownloads;
        }
    }
}
