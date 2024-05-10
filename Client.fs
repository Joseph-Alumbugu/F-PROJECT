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
    let CreditRequest() =
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
  let Chartpage (name, ux, options, message, pp) =
     // Get the canvas element for the chart
     let canvas = JsInterop.GetElementById "experienceChart" :?> Dom.CanvasElement
     let ctx = canvas.Context2D

     // Define data for the chart
     let labels = [|"Dissatisfied"; "Neutral"; "Satisfied"; "Delighted"|]
     let data = [|options.Dissatified; options.Neutral; options.Satisfied; options.Delighted|]
     
     // Clear previous chart
     ctx.ClearRect(0.0, 0.0, canvas.Width.ToFloat(), canvas.Height.ToFloat())

     // Draw the chart using Chart.js
     ChartJs.Chart(ctx, {| 
         Type = ChartType.Bar;
         Data = {
             Labels = labels;
             Datasets = [| {| Label = "Customer Experience"; Data = data; BackgroundColor = [| "#ff6384"; "#36a2eb"; "#ffce56"; "#4bc0c0"|]; BorderColor = [| "#ff6384"; "#36a2eb"; "#ffce56"; "#4bc0c0"|]; BorderWidth = 1 |} |];
         };
         Options = {| Scales = {| Y = {| BeginAtZero = true |} |} |}
     |}) |> ignore

       
