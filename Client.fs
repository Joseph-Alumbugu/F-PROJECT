namespace Project8

open WebSharper
open WebSharper.UI
open WebSharper.UI.Templating
open WebSharper.UI.Notation
open WebSharper.Forms
open WebSharper.JavaScript
 open WebSharper.UI.Client

[<JavaScript>]
module Templates =

    type MainTemplate = Templating.Template<"Main.html", ClientLoad.FromDocument, ServerLoad.WhenChanged>

[<JavaScript>]
module Client =
    open WebSharper.Charting
    open WebSharper.ChartJs

    let Main () =
        let rvCapitalized  = Var.Create ""
        Templates.MainTemplate.MainForm()
            .OnSend(fun e ->
                async {
                    let inputText = e.Vars.Texter.Value
                    let capitalizedText = inputText.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
                                                 |> Array.map (fun word -> word.[0].ToString().ToUpper() + word.[1..].ToLower())
                                                 |> String.concat " "
                    
                    let greeting = sprintf "Hello, %s! Welcome this webshaeper templating" capitalizedText
                    rvCapitalized := greeting
                  

                }
                |> Async.StartImmediate
            )
            .Reversed(rvCapitalized.View)
            .Doc()
    let CustomerFeedback() =
        Form.Return (fun name ux options message pp ->
            name, ux, options, message, pp)
        <*> (Form.Yield "" |> Validation.IsNotEmpty "Can't be empty")
        <*> Form.Yield ""
        <*> Form.Yield ""
        <*> Form.Yield ""
        <*> Form.Yield false
        |> Form.WithSubmit
        |> Form.Run (fun ((name, ux, options, message, pp) as data) ->
            JS.Alert $"You submitted: {data}"
        )
        |> Form.Render (fun name ux options message pp submitter ->
            Templates.MainTemplate.Form1()
                .Title("Thank you for leave a feedback")              
                .Name(name)
                .ux(ux)
                .Message(message)
                .PrivacyPolicy(pp)
                .OnSubmit(fun e -> submitter.Trigger())
                .Doc()
        )

    let SummaryPage () =
        let data = [|
            "Dissatisfied", 10.
            "Satisfied", 20.
            "Neutral", 50.
            "Good", 30.
            "Excellent", 75.
        |]
        let chart = Chart.Bar data
        Renderers.ChartJs.Render(chart, Size = Size(500, 350))
