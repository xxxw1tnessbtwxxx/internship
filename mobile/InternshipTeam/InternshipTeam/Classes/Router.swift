//
//  Router.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation
import UIKit

final class Router {
    
    static let navigator = Router()
    
    func pushMainMenu(from fromvc: UIViewController) {
        let story = UIStoryboard(name: "MainMenu", bundle: nil)
        let vc = story.instantiateViewController(withIdentifier: "MainMenuStoryboard") as! MainMenu
        fromvc.navigationController?.pushViewController(vc, animated: true)
    }
    
    func pushProfileSettings(from fromvc: UIViewController) {
        let story = UIStoryboard(name: "ProfileSettings", bundle: nil)
        let vc = story.instantiateViewController(withIdentifier: "ProfileSettingsStoryboard") as! ProfileSettingsViewController
        fromvc.navigationController?.pushViewController(vc, animated: true)
    }

    
}
