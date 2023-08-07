
using Sandbox;

namespace AEExampleModule;



public static class AEExampleModule
{
    /**
     * The AEExampleModule contains:
     * - A copy of the scale command from the base Admin Essentials addon renamed to escale.
     * - More coming soon.
     */
    
    
    //The ae_startup event automatically gets ran after everything is loaded in. (Aka ready for modules to load custom commands and such)
    [Event("ae_startup")]
    public static void SetupCommands()
    {
        //Register ExampleScaleCommand.
        AdminEssentials.AdminEssentials.RegisterCommand(new ExampleScaleCommand());
    }
}