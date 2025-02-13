using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace StardewModdingAPI.Web.Framework;

/// <summary>Generic metadata about a mod.</summary>
internal class ModInfoModel
{
    /*********
    ** Accessors
    *********/
    /// <summary>The mod name.</summary>
    public string? Name { get; private set; }

    /// <summary>The mod's web URL.</summary>
    public string? Url { get; private set; }

    /// <summary>The mod's latest version.</summary>
    public ISemanticVersion? Version { get; private set; }

    /// <summary>The mod's latest optional or prerelease version, if newer than <see cref="Version"/>.</summary>
    public ISemanticVersion? PreviewVersion { get; private set; }

    /// <summary>The mod availability status on the remote site.</summary>
    public RemoteModStatus Status { get; private set; }

    /// <summary>The error message indicating why the mod is invalid (if applicable).</summary>
    public string? Error { get; private set; }

    /// <summary>The mod page URL from which <see cref="Version"/> can be downloaded, if different from the <see cref="Url"/>.</summary>
    public string? MainModPageUrl { get; private set; }

    /// <summary>The mod page URL from which <see cref="PreviewVersion"/> can be downloaded, if different from the <see cref="Url"/>.</summary>
    public string? PreviewModPageUrl { get; private set; }


    /*********
    ** Public methods
    *********/
    /// <summary>Construct an empty instance.</summary>
    public ModInfoModel() { }

    /// <summary>Construct an instance.</summary>
    /// <param name="name">The mod name.</param>
    /// <param name="url">The mod's web URL.</param>
    /// <param name="version">The semantic version for the mod's latest release.</param>
    /// <param name="previewVersion">The semantic version for the mod's latest preview release, if available and different from <see cref="Version"/>.</param>
    /// <param name="status">The mod availability status on the remote site.</param>
    /// <param name="error">The error message indicating why the mod is invalid (if applicable).</param>
    [JsonConstructor]
    public ModInfoModel(string name, string url, ISemanticVersion? version, ISemanticVersion? previewVersion = null, RemoteModStatus status = RemoteModStatus.Ok, string? error = null)
    {
        this
            .SetBasicInfo(name, url)
            .SetMainVersion(version!)
            .SetPreviewVersion(previewVersion)
            .SetError(status, error!);
    }

    /// <summary>Set the basic mod info.</summary>
    /// <param name="name">The mod name.</param>
    /// <param name="url">The mod's web URL.</param>
    [MemberNotNull(nameof(ModInfoModel.Name), nameof(ModInfoModel.Url))]
    public ModInfoModel SetBasicInfo(string name, string url)
    {
        this.Name = name;
        this.Url = url;

        return this;
    }

    /// <summary>Set the mod's main version info.</summary>
    /// <param name="version">The semantic version for the mod's latest stable release.</param>
    /// <param name="modPageUrl">The mod page URL from which <paramref name="version"/> can be downloaded, if different from the <see cref="Url"/>.</param>
    [MemberNotNull(nameof(ModInfoModel.Version))]
    public ModInfoModel SetMainVersion(ISemanticVersion version, string? modPageUrl = null)
    {
        this.Version = version;
        this.MainModPageUrl = modPageUrl;

        return this;
    }

    /// <summary>Set the mod's preview version info.</summary>
    /// <param name="version">The semantic version for the mod's latest preview release.</param>
    /// <param name="modPageUrl">The mod page URL from which <paramref name="version"/> can be downloaded, if different from the <see cref="Url"/>.</param>
    public ModInfoModel SetPreviewVersion(ISemanticVersion? version, string? modPageUrl = null)
    {
        this.PreviewVersion = version;
        this.PreviewModPageUrl = modPageUrl;

        return this;
    }

    /// <summary>Set a mod error.</summary>
    /// <param name="status">The mod availability status on the remote site.</param>
    /// <param name="error">The error message indicating why the mod is invalid (if applicable).</param>
    public ModInfoModel SetError(RemoteModStatus status, string error)
    {
        this.Status = status;
        this.Error = error;

        return this;
    }
}
