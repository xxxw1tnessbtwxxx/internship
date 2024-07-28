//
//  SettingsViewController.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 18.06.2024.
//

import UIKit

class SettingsViewController: UIViewController {

    
    // MARK: - Outlets
    
    
    @IBOutlet weak var currentSalaryTextField: UITextField!
    
    // MARK: - Lifecycle
    override func viewDidLoad() {
        super.viewDidLoad()
        requestSaveSalary()
        var tap = UITapGestureRecognizer(target: self, action: #selector(hideKeyboard))
        view.addGestureRecognizer(tap)
    }
    
    @objc func hideKeyboard() {
        view.endEditing(true)
    }
    
    private func requestSaveSalary() {
        
        let salary = (UserDefaults.standard.string(forKey: "salary"))
        
        guard let salary = salary else {
            return
        }
        
        let alert = UIAlertController(title: "Сохраненная ставка", message: "Загрузить установленную ставку для воспоминаний?", preferredStyle: .alert)
        
        let cancelAction = UIAlertAction(title: "Отмена", style: .cancel)
        let loadAction = UIAlertAction(title: "Загрузить", style: .default) { _ in
            self.currentSalaryTextField.text = salary
        }
        
        alert.addAction(cancelAction)
        alert.addAction(loadAction)
        self.present(alert, animated: true)
        
        
    }
    
    override func viewDidAppear(_ animated: Bool) {
        
    }

    @IBAction func didTapSaveBtn(_ sender: Any) {
        
        if (currentSalaryTextField.text?.isEmpty == true) {
            
            AlertsCreator.MakePrimitiveAlert(vc: self, title: "Пустое поле", message: "Поле почасовой ставки должно быть заполнено!", buttonTitle: "Попробовать снова")
            return
        }
        
        if let salary = Double(currentSalaryTextField.text!) {
            UserDefaults.standard.setValue(salary, forKey: "salary")
        }
        else {
            AlertsCreator.MakePrimitiveAlert(vc: self, title: "Ошибка", message: "Почасовая ставка должна быть числом", buttonTitle: "Попробовать снова")
        }
        
    }
    
    
    @IBAction func didTapProfileSettings(_ sender: Any) {
        
        Router.navigator.pushProfileSettings(from: self)
        
    }
    
    
}
