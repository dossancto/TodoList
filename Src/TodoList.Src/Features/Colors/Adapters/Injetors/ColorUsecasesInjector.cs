using TodoList.Src.TodoList.Src.Features.Colors.Application.CreateColor;
using TodoList.Src.TodoList.Src.Features.Colors.Application.DeleteColor;
using TodoList.Src.TodoList.Src.Features.Colors.Application.SelectColor;

namespace TodoList.Src.TodoList.Src.Features.Colors.Adapters.Injetors;

public static class ColorUsecasesInjector
{
    public static IServiceCollection AddColorUsecases(this IServiceCollection services)
      => services
            .AddScoped<CreateColorUsecase>()
            .AddScoped<SelectColorUsecase>()
            .AddScoped<DeleteColorUsecase>()
      ;
}
