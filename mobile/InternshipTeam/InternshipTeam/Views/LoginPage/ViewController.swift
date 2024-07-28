//
//  ViewController.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 17.06.2024.
//

import UIKit
import Alamofire
class ViewController: UIViewController {

    
    // MARK: - Outlets
    
    

    @IBOutlet weak var authButton: UIButton!
    @IBOutlet weak var passwordTextField: UITextField!
    @IBOutlet weak var loginTextField: UITextField!
    @IBOutlet weak var helloLabel: UILabel!
    @IBOutlet weak var authorizeLabel: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        authButton.isHidden = true
        passwordTextField.isSecureTextEntry = true
        animateUi() {
            self.authButton.isHidden = false
        }
        
    }

    override func viewWillAppear(_ animated: Bool) {
        CredentialsLoader.downloadCredentials { credentials in
            guard let login = credentials?.login, let password = credentials?.password else {
                return
            }
            
            APIManager.getEmployee(authRequest: AuthorizeRequest(login: login, password: password)) { employee in
                CurrentData.employee = employee
                Router.navigator.pushMainMenu(from: self)
            }
            
        }
    }
    
    
    // MARK: - Event Handlers
    
    @IBAction func didTapAuthBtn(_ sender: Any) {
        APIManager.getEmployee(authRequest: AuthorizeRequest(login: loginTextField.text!, password: passwordTextField.text!)) { data in
            
            guard let _ = data else {
                
                AlertsCreator.MakePrimitiveAlert(vc: self, title: "Ошибка", message: "Введены неверные данные", buttonTitle: "Попробовать снова")
                return
            }
            CurrentData.employee = data
            UserDefaults.standard.setValue(self.loginTextField.text!, forKey: "login")
            UserDefaults.standard.setValue(self.passwordTextField.text!, forKey: "password")
            Router.navigator.pushMainMenu(from: self)
            
        }
        
    }
    
    
    // MARK: - Animation
    
    private func animateUi(completion: @escaping() -> Void) {
        // Hide all outlets
        passwordTextField.alpha = 0
        loginTextField.alpha = 0
        helloLabel.alpha = 0
        authorizeLabel.alpha = 0
        
        UIView.animate(withDuration: 2) {
            self.authorizeLabel.layer.opacity = 1
            self.helloLabel.alpha = 1
        }
        
        UIView.animate(withDuration: 3) {
            self.passwordTextField.alpha = 1
            self.loginTextField.alpha = 1
            
        }
        
        completion()
    }

}

