using System.Collections.Generic;
using AdminEssentials.commands;
using Sandbox;

namespace AEExampleModule;

public class ExampleScaleCommand : BaseCommand
{
    /**
     * Admin Essentials automatically handles backbone command logic. You just have to give your specific command the logic in DoCommand.
     * A permission will automatically get generated via BaseCommand.GetPermissionIdentifier(). The identifier will look like org.commandName in this case "fun.escale"
     * A command has to be registered. See AEExampleModule.cs
     */
    public ExampleScaleCommand()
    {
        commandName = "escale";
        org = "fun";
        helpText = "Set the scale of a player. default=1.0. This is apart of the Admin Essentials Example Module. It is a copy of the scale command from Admin Essentials.";
        arguments = new KeyValuePair<string, EArgumentType>[]
        {
            new KeyValuePair<string, EArgumentType>("target", EArgumentType.PLAYER),
            new KeyValuePair<string, EArgumentType>("scale", EArgumentType.STRING),
        };
    }

    /**
     * DoCommand will automatically get handled once you register the command (See AEExampleModule.cs)
     * Only users with a role that has the permission to use this command can use it.
     */
    protected override void DoCommand(IClient callingUser, params string[] args)
    {
        IClient client = AttemptGetClient(args[0]); //AttemptGetClient takes in a player name OR a steam ID and will do its best to find that user.
        float size = float.Parse(args[1]);

        if (client != null)
        {
            ModelEntity ent = (ModelEntity)client.Pawn;
            if (ent != null)
            {
                ent.Scale = size;
                CallerPrint(callingUser,"Scale of "+client.Name+" changed to "+size); //CallerPrint will print to the Client provided.
            }
            else
            {
                CallerPrint(callingUser,"Couldn't get modelentity, may be incompatible with the current gamemode/player pawn.");
            }
        }
        else
        {
            CallerPrint(callingUser,"Couldn't find the user "+args[0]);
        }
        
    }
}