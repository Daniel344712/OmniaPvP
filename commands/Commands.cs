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
            await ctx.Channel.SendMessageAsync($"Hola {ctx.User.Username} laa ip del servidor es `play.omniapvp.com`");
        }
        [Command("Borrar")]
        public async Task Borrar (CommandContext ctx, int cantidad)
        {
            if(ctx.Member.Roles.Any(r => r.Name == "Staff"))
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
