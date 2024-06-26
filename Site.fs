namespace Project8

open WebSharper
open WebSharper.Sitelets
open WebSharper.UI
open WebSharper.UI.Server

type EndPoint =
    | [<EndPoint "/">] Home
    | [<EndPoint "/feedback">] CustomerFeedback
    | [<EndPoint "/summary">] Summary

module Templating =
    open WebSharper.UI.Html

    // Compute a menubar where the menu item for the given endpoint is active
    let MenuBar (ctx: Context<EndPoint>) endpoint : Doc list =
        let ( => ) txt act =
            let isActive = if endpoint = act then "nav-link active" else "nav-link"
            li [attr.``class`` "nav-item"] [
                a [
                    attr.``class`` isActive
                    attr.href (ctx.Link act)
                ] [text txt]
            ]
        [
            "Home" => EndPoint.Home
            "Form" => EndPoint.CustomerFeedback
            "Summary" => EndPoint.Summary
        ]

    let Main ctx action (title: string) (body: Doc list) =
        Content.Page(
            Templates.MainTemplate()
                .Title(title)
                .MenuBar(MenuBar ctx action)
                .Body(body)
                .Doc()
        )

module Site =
    open WebSharper.UI.Html

    open type WebSharper.UI.ClientServer

    let HomePage ctx =
        Templating.Main ctx EndPoint.Home "Home" [
            h1 [] [text "Kindly enter your name"]
            div [] [client (Client.Main())]
        ]

    let CustomerFeedbackPage ctx =
        Templating.Main ctx EndPoint.CustomerFeedback "Form" [
            h1 [] [text "Contact Form"]
            div [] [client (Client.CustomerFeedback())]
        ]

    let SummaryPage ctx =
        Templating.Main ctx EndPoint.Summary "Summary" [
            h1 [] [text "Customer feedback so far"]
            div [] [client (Client.SummaryPage())]
        ]

    [<Website>]
    let Main =
        Application.MultiPage (fun ctx endpoint ->
            match endpoint with
            | EndPoint.Home -> HomePage ctx
            | EndPoint.CustomerFeedback -> CustomerFeedbackPage ctx
            | EndPoint.Summary -> SummaryPage ctx
        )

