//
//  HomeViewController.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 18.06.2024.
//

import UIKit

class HomeViewController: UIViewController {

    @IBOutlet weak var employeeWelcomeTitle: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()

        // Do any additional setup after loading the view.
    }

    // MARK: - Settings Up
    
    /// Function that returns system hour
    private func getGreeting() -> String? {
        let hour = Calendar.current.component(.hour, from: Date())
        
        if ((6...12).contains(hour)) {
            return "Доброе утро"
        }
        else if ((13...16).contains(hour)) {
            return "Добрый день"
        }
        else if ((17...21).contains(hour)) {
            return "Добрый вечер"
        }
        else {
            return "Доброй ночи"
        }
        
    }
    
    
    
    private func settingsUpWelcomeTitle(_ employeeName: String?) {
        
        let greeting = getGreeting()!

        guard let name = employeeName else {
            employeeWelcomeTitle.text = "\(greeting), undefined!"
            return
        }
        
        employeeWelcomeTitle.text = "\(greeting), \(name)!"
        
        
    }
    
    
    // MARK: - Lifecycle
    override func viewWillAppear(_ animated: Bool) {
        
        settingsUpWelcomeTitle(CurrentData.employee?.name)
        
    }
    
    
    @IBAction func didTapLogoutBtn(_ sender: Any) {
        CurrentData.disposeDefaults()
        self.navigationController?.popToRootViewController(animated: true)
        
    }
    
}
