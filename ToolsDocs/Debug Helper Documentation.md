## Available Commands

The Debug Helper provides several commands to assist with debugging and gameplay manipulation. Here's a list of the currently available commands and their functions:
### 1. Clear

**Usage:** `clear`**Function:** Clears the console log history.

### 2. Teleport (tp)

**Usage:** `tp <location>` or `teleport <location>`**Function:** Teleports the player to a predefined location.

**Example:** `tp cylo` or `teleport cylo`

### 3. ToggleFreeCam (tfc)

**Usage:** `tfc` or `togglefreecam`**Function:** Toggles between the player view and a free camera mode.

### 4. Help

**Usage:** `help`**Function:** Displays a list of available commands.

### 5. SetLuaVar - Not Yet Implemented

**Usage:** `setluavar <variable_name> <value>`**Function:** Sets a Lua variable to the specified value.

**Example:** `setluavar FatherPermission true`

### 6. Swap

**Usage:** `swap <level>`**Function:** Attempts to switch to a different memory level.

**Example:** `swap 2`

## Command Formatting

Commands can be entered in two formats:

1. **Space-separated:** Command followed by arguments, separated by spaces.

> Example: `tp cylo`

2. **Function-style:** Command followed by parentheses containing comma-separated arguments.

> Example: `teleport(cylo)`

Both formats are equivalent and will be processed correctly by the Debug Helper.

## Aliases

Some commands have aliases for ease of use:

- `tp` is an alias for `teleport`

- `tfc` is an alias for `togglefreecam`

## Activating the Debug Console

To activate the debug console:

1. Press the backtick key (`) to toggle the console on/off.

2. When the console is active, player or camera movement is disabled.

3. Type your command and press Enter to execute.

## Notes

- Commands are case-insensitive.

- The console will provide feedback for each command executed, including error messages for invalid commands or arguments.

- Some commands may have different effects depending on the current game state or available objects in the scene.

  

## Adding new commands:

- create a new method in the DebugHelper.cs class

    - that’s it 🙂

    - oh and update this document