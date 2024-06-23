using ConsoleAppDevTools.StepManager;

await StepManager.RunAsync(async () =>
{
    string input = "進行腳本";

    var first = await StepManager.Step("開始第一階段", input, async (x) =>
    {
        await Task.Delay(3000);
        return x + " ABC";
    });

    var result = await StepManager.Step("開始第二階段", first, async (x) =>
    {
        await Task.Delay(2000);
        return $"{x} DEF";
    });

    Console.WriteLine("---------------------------------------");
    Console.WriteLine(result);
});