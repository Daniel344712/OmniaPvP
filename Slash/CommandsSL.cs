using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniaPvP.Slash
{
    public class CommandsSL : ApplicationCommandModule
    {
        [SlashCommand("poll", "Crea una encuesta con hasta 5 opciones.")]
        public async Task PollCommand(InteractionContext ctx,
            [Option("titulo", "El título de la encuesta")] string title = "Encuesta",
            [Option("opcion1", "La primera opción de la encuesta")] string option1 = null,
            [Option("opcion2", "La segunda opción de la encuesta")] string option2 = null,
            [Option("opcion3", "La tercera opción de la encuesta")] string option3 = null,
            [Option("opcion4", "La cuarta opción de la encuesta")] string option4 = null,
            [Option("opcion5", "La quinta opción de la encuesta")] string option5 = null)
        {
            if(ctx.Member.Roles.Any(r => r.Name == "Owner"))
            {
                // Crear lista de opciones sin valores nulos o vacíos
                List<string> options = new List<string> { option1, option2, option3, option4, option5 }.Where(opt => !string.IsNullOrEmpty(opt)).ToList();
            
                // Verificar si hay al menos una opción
                if (options.Count == 0)
                {
                    await ctx.CreateResponseAsync(new DiscordInteractionResponseBuilder()
                        .WithContent("Debe proporcionar al menos una opción para la encuesta.")
                        .AsEphemeral(true));
                    return;
                }

                // Construir el mensaje de la encuesta
                var embed = new DiscordEmbedBuilder
                {
                    Title = title,
                    Color = DiscordColor.Cyan // Color celeste
                    
                };

                for (int i = 0; i < options.Count; i++)
                {
                    embed.AddField(GetEmojiForIndex(ctx.Client, i) + " Opción " + (i + 1), options[i]);
                }

                
                var message = await ctx.Channel.SendMessageAsync(embed: embed);

                
                for (int i = 0; i < options.Count; i++)
                {
                    await message.CreateReactionAsync(GetEmojiForIndex(ctx.Client, i));
                }

                // Responder al usuario que el comando se ejecutó correctamente
                await ctx.CreateResponseAsync(new DiscordInteractionResponseBuilder().WithContent("La encuesta ha sido creada.").AsEphemeral(true));
            }
            else
            {
                await ctx.CreateResponseAsync(new DiscordInteractionResponseBuilder()
                    .WithContent("No tienes permisos para usar este comando.")
                    .AsEphemeral(true));
            }
            
        }

        private DiscordEmoji GetEmojiForIndex(DiscordClient client, int index)
        {
            switch (index)
            {
                case 0:
                    return DiscordEmoji.FromName(client, ":one:");
                case 1:
                    return DiscordEmoji.FromName(client, ":two:");
                case 2:
                    return DiscordEmoji.FromName(client, ":three:");
                case 3:
                    return DiscordEmoji.FromName(client, ":four:");
                case 4:
                    return DiscordEmoji.FromName(client, ":five:");
                default:
                    throw new ArgumentOutOfRangeException(nameof(index), "Index fuera de rango para emojis.");
            }
        }
    }
}
