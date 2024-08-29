using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.VoiceNext;
using NAudio.MediaFoundation;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Common;


namespace OmniaPvP.commands
{
    public class Commands : BaseCommandModule
    {
        private readonly YoutubeClient _youtubeClient;
        [Command("ip")]
        public async Task IP(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hola {ctx.User.Mention} la ip del servidor es `play.omniapvp.com`");
        }
        [Command("Borrar")]
        public async Task Borrar(CommandContext ctx, int cantidad)
        {
            if (ctx.Member.Roles.Any(r => r.Name == "Staff"))
            {
                var messages = await ctx.Channel.GetMessagesAsync(cantidad);
                await ctx.Channel.DeleteMessagesAsync(messages);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("No tienes permisos para usar este comando");
            }
        }

     
        [Command("play")]
        public async Task Play(CommandContext ctx, string link)
        {
            if (ctx.Member == null || ctx.Member.VoiceState == null || ctx.Member.VoiceState.Channel == null)
            {
                await ctx.Channel.SendMessageAsync("Debes estar en un canal de voz para usar este comando");
                
            }

            var voiceChannel = ctx.Member.VoiceState.Channel;
            var voiceNext = ctx.Client.GetVoiceNext();

            var connection = await voiceNext.ConnectAsync(voiceChannel);

           
        }
    }


    }
           

        
 
