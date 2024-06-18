//
//  SettingsViewController.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 18.06.2024.
//

import UIKit

class ProfileSettingsViewController: UIViewController {


    @IBOutlet weak var phoneNumberTextField: UITextField!
    @IBOutlet weak var patronymicTextField: UITextField!
    @IBOutlet weak var nameTextField: UITextField!
    @IBOutlet weak var surnameTextField: UITextField!
    override func viewDidLoad() {
        super.viewDidLoad()
        setTextFieldData()
        changeStatement(state: .disabled)
    }

    
    private func setTextFieldData() {
        
        guard let name = CurrentData.employee?.name,
              let surname = CurrentData.employee?.surname,
              let patronymic = CurrentData.employee?.patronymic,
              let phoneNumber = CurrentData.employee?.phoneNumber
        else {
            print("tyt null")
            return
        }
                
        surnameTextField.text = surname
        nameTextField.text = name
        patronymicTextField.text = patronymic
        phoneNumberTextField.text = phoneNumber
        
    }
    
    private func changeStatement(state: EditorEnumerable) {
        
        switch (state) {
        case .enabled:
            for view in self.view.subviews {
                if let field = view as? UITextField {
                    field.isEnabled = true
                }
            }
            break
        case .disabled:
            for view in self.view.subviews {
                if let field = view as? UITextField {
                    field.isEnabled = false
                }
            }
            break
        }
        
    }
    

    @IBAction func didTapSaveBtn(_ sender: Any) {
        changeStatement(state: .disabled)
    }
    
    @IBAction func didTapEditBtn(_ sender: Any) {
        
        changeStatement(state: .enabled)
        surnameTextField.becomeFirstResponder()
    }
}
