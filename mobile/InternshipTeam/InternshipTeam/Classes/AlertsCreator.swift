//
//  AlertsCreator.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import Foundation
import UIKit
class AlertsCreator {
    
    /// Function. that creates default alert without completion handler
    static func MakePrimitiveAlert(vc: UIViewController, title: String, message: String, buttonTitle: String) {
        let alert = UIAlertController(title: title, message: message, preferredStyle: .alert)
        alert.addAction(UIAlertAction(title: buttonTitle, style: .default))
        vc.present(alert, animated: true)
    }
}
