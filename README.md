<img width="200" alt="UI Toolkit Timeline Logo" src="https://user-images.githubusercontent.com/8857844/235506200-c5d6098b-9caa-45e4-bbcf-829292b1a9b8.png">

UI Toolkit Timeline is an open-source repository / UPM Package containing extensions for Unity Timeline that enable animating VisualElements. It contains a timeline track and clips that allow users to select and animate UI Toolkit VisualElements - all transform values are supported, in addition to some commonly used styles, like Opacity, Visibility, and Display. It also allows adding / removing classes directly from Timeline. The selector syntax is similar to the way selectors work in Unity Style Sheets (USS).

## Usage

Add the package to your project via Unity Package Manager (use the `Add package from git URL` option).

1. Create a new Playable Director that is a child of the UI Document you will be animating. Internally the timeline track uses `GetComponentInParent<UIDocument>()` to fetch the UI Document.

2. In your timeline add a new VisualElement track: UITTimeline -> UIT VisualElement Track.

3. To animate elements, you need to open the Game view, which should be rendering your UXML.

4. Start adding clips and animating your VisualElements! The package also includes samples showcasing all the clips / tracks (which you can import from the Package Manager).

## VisualElement Track

The package includes a single `UIT Visual Element Track`, that is used by all the supported clips. The track also supports layers (although be mindful that there is no special layer mixing, so don't animate the same property at the same time on multiple layers).

Elements are selected by writing a more-or-less standard USS selector in the name of the timeline track. If multiple elements match the selector, the track will apply the animation to all of them (useful for reusing animations based on class names, for example).

<img width="355" alt="Timeline Track Examples" src="https://user-images.githubusercontent.com/8857844/235454054-5a882a12-f608-49df-81fe-684709a33879.png">

_Note: this system might get changed if there is demand for custom track names._

### Supported Selectors

#### Name Selector (#Name)

To select an element by its name, use a hashtag (#) followed by the name of the element. For example, the selector `#PlayButton` would select an element with the name "PlayButton".

#### Class Selector (.class)

To select an element by its class, use a period (.) followed by the class name. For example, the selector `.my-class` would select an element with the "my-class" class.

#### Descendant Selector (" ")

To select a descendant element, combine two selectors with a space ( ). For example, the selector `#PlayButton .icon` would select an element with the "icon" class that is a child of an element with the "PlayButton" name.

#### Mix and Match Selectors

You can also mix and match Name and Class selectors to create more complex selectors. For example, the selector `#PlayButton .icon.animated` would select an element that has both the "icon" and "animated" classes and is a child of an element with the "PlayButton" name.

#### Type selectors

Type selectors are currently not supported.

### Example Usage

Here are some examples of selectors:

- `#PlayButton`: Selects an element with the name "PlayButton".
- `.my-class`: Selects an element with the "my-class" class.
- `#PlayButton .icon`: Selects an element with the "icon" class that is a child of an element with the "PlayButton" name.
- `.my-class .icon.animated`: Selects an element that has both the "icon" and "animated" classes and is a child of an element with the "my-class" class.


## Available Clips

The package includes a set of clips for animating base transform properties (Position, Rotation, Scale), as well as clips for toggling Display and Visibility on or off. Additionally, it includes a clip that allows enabling/disabling a class on a UI Toolkit element.

All normal Timeline operations can be done on the clips, including blending, extrapolation, ease in/out, and manipulating curves. Some clips that do not hold number values (Display, Visibility, Class) cannot be blended / have curves.

### List of Clips

- Position (`UITPositionClip`): Animates the position of the selected VisualElement.
- Rotation (`UITRotationClip`): Animates the rotation of the selected VisualElement.
- Scale (`UITScaleClip`): Animates the scale of the selected VisualElement.
- Display (`UITDisplayClip`): Toggles the display of the selected VisualElement on or off.
- Visibility (`UITVisibilityClip`): Toggles the visibility of the selected VisualElement on or off.
- Class Toggle (`UITClassToggle`): Enables or disables a class on the selected VisualElement.

### Usage

Right click on your track and add the clip you want. Clips that animate number types (e.g. position / opacity...) can be blended, and you can set up custom curves for them.

<img width="802" alt="Clip Examples" src="https://user-images.githubusercontent.com/8857844/235455165-3cd9471f-6b14-4e46-86f9-98ee22e2049e.png">

## Performance

The performance of your timeline will greatly depend on what you are animating and how.

UITT tries to optimize the rendering performance by automatically enabling [UsageHints](https://docs.unity3d.com/ScriptReference/UIElements.UsageHints.html) on your VisualElements, based on the clips that you are using in your track (e.g. having a Position clip will automatically add the DynamicTransform usage hint to your element).

In general animating the transform of a VisualElement is quite efficient, while animating / changing values that trigger a layout recalculation can severely impact the FPS of your game. Be mindful of this when setting up your timeline.

_If you want more control of how UsageHints are set up you can disable automatic UsageHints in the track inspector._

# Samples

The package includes samples you can import from the Package Manager.

[Example Usage](https://user-images.githubusercontent.com/8857844/235457028-4dc5aa2f-2bc5-45b7-a8b6-f3e3f004dbf8.mov)

# Troubleshooting
 - PlayOnAwake option does not work on a Playable Director, as the UI Document is not initialized yet at that point. To get around the problem you can use the DelayedPlayOnAwake MonoBehaviour provided in this package, or write your own trigger logic.
 - Make sure you don't have transition values defined for the properties you are animating from Timeline (e.g. transition-duration) as that could / will mess with how the animations are processed.

# License

UI Toolkit Timeline is released under the MIT License. See LICENSE.md for more information.
