using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmniaPvP.commands
{
    public class Commands : BaseCommandModule
    {
        [Command("ip")]
        public async Task IP(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hola {ctx.User.Username} la IP del servidor es `omniapvp.com`");
        }
        [Command("Borrar")]
        public async Task Borrar(CommandContext ctx, int cantidad)
        {
            var allowedRoles = new[] { "Owner", "All Perms", "Manager" };

            if(ctx.Member.Roles.Any(r => allowedRoles.Contains(r.Name)))
            {
                var messages = await ctx.Channel.GetMessagesAsync(cantidad);
                await ctx.Channel.DeleteMessagesAsync(messages);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("No tienes permisos para usar este comando");
            }
        }

       
    }
}
