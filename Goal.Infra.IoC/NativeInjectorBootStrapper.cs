using FluentMediator;
using Goal.Application.Handlers;
using Goal.Application.Mappers;
using Goal.Application.Services;
using Goal.Domain.Items;
using Goal.Domain.Items.Commands;
using Goal.Domain.Items.Events;
using Goal.Infra.Factories;
using Goal.Infra.Repositories;
using Jaeger;
using Jaeger.Samplers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;
using System.Reflection;

namespace Goal.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IItemService, ItemService>();
            services.AddTransient<IItemRepository, ItemRepository>(); //just as an example, you may use it as .AddScoped
            services.AddSingleton<ItemViewModelMapper>();
            services.AddTransient<IItemFactory, EntityFactory>();

            services.AddScoped<ItemCommandHandler>();
            services.AddScoped<ItemEventHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddFluentMediator(builder =>
            {
                builder.On<CreateNewItemCommand>().PipelineAsync().Return<Item, ItemCommandHandler>((handler, request) => handler.HandleNewItem(request));

                builder.On<ItemCreatedEvent>().PipelineAsync().Call<ItemEventHandler>((handler, request) => handler.HandleItemCreatedEvent(request));

                builder.On<DeleteItemCommand>().PipelineAsync().Call<ItemCommandHandler>((handler, request) => handler.HandleDeleteItem(request));

                builder.On<ItemDeletedEvent>().PipelineAsync().Call<ItemEventHandler>((handler, request) => handler.HandleItemDeletedEvent(request));
                
                builder.On<ItemExpiredEvent>().PipelineAsync().Call<ItemEventHandler>((handler, request) => handler.HandleItemExpireEvent(request));
            });

            services.AddSingleton(serviceProvider =>
            {
                var serviceName = Assembly.GetEntryAssembly().GetName().Name;

                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

                ISampler sampler = new ConstSampler(true);

                ITracer tracer = new Tracer.Builder(serviceName)
                    .WithLoggerFactory(loggerFactory)
                    .WithSampler(sampler)
                    .Build();

                GlobalTracer.Register(tracer);

                return tracer;
            });

        }
    }
}