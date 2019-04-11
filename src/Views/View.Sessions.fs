module App.Views.Sessions

open Fable.Helpers.React
open Fable.Helpers.React.Props
open App.Types


let session dispatch s =
  div [ Class "bg-white w-full rounded-lg shadow-lg p-2 md:p-8 mt-6" ]
    [ div [ Class "font-bold my-2" ]
        [ str s.title ]
      div [ Class "" ]
        [ (match s.img with
            | Some pic ->
                  img [ Class "w-64 textwrap pr-2"
                        Src pic ]
            | None -> div [] [] )
        
          str s.description ]
        
      div [ Class "mt-4 pt-2 border-t border-solid" ]
        [ (match s.link with
            | Some l ->
                  a [ Class "link"
                      Href l.url
                      Target "_blank"]
                    [ str l.label ]
            | None -> div [] [] )
         ] ]
    
let sessions model dispatch =
  div [ Class "content bg-grey-lighter" ; Id "sessions"]
    [ div [ Class "my-8 w-4/5 lg:w-2/3 xl:w-1/2" ]
        [ h2 [ ]
                [ str "Sessions"]
          div [ Class "flex flex-col items-center justify-start" ]
            (model.sessions
            |> List.map (function Past_session s -> (session dispatch s) | Upcoming_session s -> (session dispatch s) ))
            
            ] ]