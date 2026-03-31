using System.Collections.Generic;
using System.Reflection;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Phlow.App.ViewModels;

/// <summary>
/// ViewModel for the About dialog showing application info and credits.
/// </summary>
public partial class AboutViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isCreditsExpanded;

    public string AppVersion { get; }

    public string DotNetVersion { get; } = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;

    public IReadOnlyList<CreditEntry> Credits { get; } =
    [
        new("Avalonia UI", "11.3.13", "Cross-platform .NET UI framework", "https://avaloniaui.net"),
        new("SukiUI", "6.0.3", "Modern Avalonia theme and controls", "https://github.com/kikipoulet/SukiUI"),
        new("CommunityToolkit.Mvvm", "8.4.2", "MVVM source generators and helpers", "https://github.com/CommunityToolkit/dotnet"),
        new("MetadataExtractor", "2.9.2", "EXIF, IPTC, and XMP metadata reader", "https://github.com/drewnoakes/metadata-extractor-dotnet"),
        new("Velopack", "0.0.1298", "Auto-update and installer framework", "https://velopack.io"),
    ];

    public AboutViewModel()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var version = assembly.GetName().Version;
        AppVersion = version is not null ? $"{version.Major}.{version.Minor}.{version.Build}" : "0.0.1";
    }
}

/// <summary>
/// Represents a third-party package credit entry.
/// </summary>
public record CreditEntry(string Name, string Version, string Description, string Url);
