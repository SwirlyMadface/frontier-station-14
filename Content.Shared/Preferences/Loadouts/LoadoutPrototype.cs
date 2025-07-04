using Content.Shared.Preferences.Loadouts.Effects;
using Content.Shared.Roles;
using Robust.Shared.Prototypes;
using Robust.Shared.Utility;

namespace Content.Shared.Preferences.Loadouts;

/// <summary>
/// Individual loadout item to be applied.
/// </summary>
[Prototype]
public sealed partial class LoadoutPrototype : IPrototype, IEquipmentLoadout
{
    [IdDataField]
    public string ID { get; private set; } = string.Empty;

    /*
     * You can either use an existing StartingGearPrototype or specify it inline to avoid bloating yaml.
     */

    /// <summary>
    /// An entity whose sprite, name and description is used for display in the interface. If null, tries to get the proto of the item from gear (if it is a single item).
    /// </summary>
    [DataField]
    public EntProtoId? DummyEntity;

    [DataField]
    public ProtoId<StartingGearPrototype>? StartingGear;

    /// <summary>
    /// Effects to be applied when the loadout is applied.
    /// These can also return true or false for validation purposes.
    /// </summary>
    [DataField]
    public List<LoadoutEffect> Effects = new();

    /// <inheritdoc />
    [DataField]
    public Dictionary<string, EntProtoId> Equipment { get; set; } = new();

    /// <inheritdoc />
    [DataField]
    public List<EntProtoId> Inhand { get; set; } = new();

    /// <inheritdoc />
    [DataField]
    public Dictionary<string, List<EntProtoId>> Storage { get; set; } = new();

    // Frontier: extra fields
    /// <inheritdoc />
    [DataField]
    [AlwaysPushInheritance]
    public List<EntProtoId> EncryptionKeys { get; set; } = new();

    /// <inheritdoc />
    [DataField]
    [AlwaysPushInheritance]
    public List<EntProtoId> Implants { get; set; } = new();

    /// <inheritdoc />
    [DataField]
    [AlwaysPushInheritance]
    public List<EntProtoId> Cartridges { get; set; } = new();
    // End Frontier: extra fields

    /// <summary>
    /// Frontier - the cost of the item simple as
    /// </summary>
    [DataField]
    public int Price = 0;

    /// <summary>
    /// Frontier - optional name of the loadout as it appears in the menu
    /// </summary>
    [DataField]
    public string Name = "";

    /// <summary>
    /// Frontier - optional description of the loadout as it appears in the menu
    /// </summary>
    [DataField]
    public string Description = "";

    /// <summary>
    /// Frontier - optional entity to use for its sprite in the loadout as it appears in the menu
    /// </summary>
    /// <remarks>
    /// Currently, if not defaulted, this will be the fallback entity used to get the description if an override is not provided here.
    /// </remarks>
    [DataField]
    public EntProtoId? PreviewEntity = default!;

    /// <summary>
    /// Frontier - effects to both validate and hide layout options in the menu
    /// </summary>
    [DataField]
    public List<LoadoutEffect> HideEffects = new();
}
