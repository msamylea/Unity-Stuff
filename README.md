# Unity-Stuff

Various scripts I've created after trying to find something useful and instead being met with gigantic packages full of stuff I don't need, want, or understand. All this contains are scripts. Nothing else.

ThirdPersonCamera: Drop this script on your main camera. Set the follow target to your character. Camera will follow behind. Pan with Right Mouse button (all directions) or middle mouse button (up and down).  Zoom with scrollwheel.

OpenMenus: Drop this script on a gameObject. Set your UI components that should not always show to Inactive (unclick the checkbox in Inspector). Then in the gameObject holding this script, drag the UI component gameObjects in along with setting the keypress that should open and close it.


Basic Item Database -- scripts: ItemDatabase, GameItem, and ItemDatabaseEditor.  (Note: you must put ItemDatabaseEditor inside Assets/Editor as it creates a window).  To use, right click and create an ItemDatabase scriptable object. Go to Window and open up Item Database Editor. Drop your ItemDatabase scriptable object inside.  Edit as needed.  To adjust the types of items, etc, edit the GameItem script.
