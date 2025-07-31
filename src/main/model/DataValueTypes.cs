namespace SimpleConnections.model
{
    /// <summary>
    /// Represents the different types of navigable pages within the Simple Connections application.
    /// Used by the PageFactory to determine which UI screen to build.
    /// </summary>
    public enum PAGETYPE
    {
        /// <summary>Main menu screen with initial navigation options.</summary>
        MAINMENU,
        /// <summary>Connections page for managing peer-to-peer links and discovery.</summary>
        CONNECTIONS,
        /// <summary>Profile screen where the user can view or edit personal details.</summary>
        PROFILE,
        /// <summary>Public or group chat interface with live message exchange.</summary>
        CHATROOM
    }

    /// <summary>
    /// Enumerates available ASCII art elements used in the TUI.
    /// Each corresponds to a unique visual theme or component (e.g., icons or headers).
    /// </summary>
    public enum ART
    {
        /// <summary>ASCII art for the Exit button.</summary>
        EXIT,
        /// <summary>ASCII art representing an Apple device.</summary>
        APPLE,
        /// <summary>ASCII art representing a gaming console.</summary>
        CONSOLE,
        /// <summary>ASCII art representing a PC device.</summary>
        PC,
        /// <summary>ASCII art representing a USB device.</summary>
        USB,
        /// <summary>ASCII art for the main title/logo of the app.</summary>
        TITLE,
        /// <summary>ASCII art used for the Connections menu or button.</summary>
        COLLECTIONS,
        /// <summary>ASCII art for the Profile screen or button.</summary>
        PROFILE,
        /// <summary>ASCII art for the Chat Room screen or button.</summary>
        CHATROOM
    }

    /// <summary>
    /// Defines identifiers for each interactive button available in the UI.
    /// Used to bind behavior when a user selects or clicks a button.
    /// </summary>
    public enum ButtonType
    {
        /// <summary>Triggers application exit.</summary>
        Exit,
        /// <summary>Opens the Connections page.</summary>
        Connections,
        /// <summary>Opens the Profile page.</summary>
        Profile,
        /// <summary>Opens the Chat Room page.</summary>
        ChatRoom,
        /// <summary>Triggers Apple-related website logic.</summary>
        Apple,
        /// <summary>Triggers Console-related website logic.</summary>
        Console,
        /// <summary>Triggers PC-related website logic.</summary>
        Pc,
        /// <summary>Triggers USB-related website logic.</summary>
        Usb,
        /// <summary>Returns the user to the Main Menu.</summary>
        MainMenu
    }

    /// <summary>
    /// Enum representing the category of device (e.g. PC, Console) for link launching.
    /// Used to select which themed media or website should be opened.
    /// </summary>
    public enum Website
    {
        /// <summary>Represents a USB device selection. Opens a USB-related video or link.</summary>
        Usb,
        /// <summary>Represents an Apple device selection. Opens a link related to Apple or macOS.</summary>
        Apple,
        /// <summary>Represents a PC device selection. Opens a PC-themed image or media.</summary>
        PC,
        /// <summary>Represents a gaming console selection. Opens console-related media.</summary>
        Console
    }

    /// <summary>
    /// Enum used to identify the current OS platform.
    /// Helps determine which process or command to use for opening links or executing platform-specific logic.
    /// </summary>
    public enum OSType
    {
        /// <summary>
        /// macOS platform (Apple systems). Uses the `open` command.
        /// </summary>
        Mac,

        /// <summary>
        /// Linux platform. Uses `xdg-open` for opening URLs.
        /// </summary>
        Linux,

        /// <summary>
        /// Windows platform. Uses `cmd /c start` for launching links.
        /// </summary>
        Windows
    }
}