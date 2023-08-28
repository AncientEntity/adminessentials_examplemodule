
using Sandbox;

namespace AEExampleModule;



public static class AEExampleModule
{
    /**
     * The AEExampleModule contains:
     * - A copy of the scale command from the base Admin Essentials addon renamed to escale.
     * - More coming soon.
     */

    private static bool initialized = false;

    static AEExampleModule()
    {
        Initialize();
    }
    
    //ae_module_IDENT will get ran after your module is mounted. This only gets ran if it is mounted via the modules tab, downloading it separately will not have this run.
    [Event("ae_module_ryan.adminessentials_examplemodule")]
    public static void Initialize()
    {
        if(initialized) {return;}
        initialized = true;
        
        AdminEssentials.AdminEssentials.RegisterCommand(new ExampleScaleCommand());
        
        Log.Info("AE Example Module Loaded.");
    }
}