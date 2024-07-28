//
//  HomeViewController.swift
//  InternshipTeam
//
//  Created by Алексей Суровцев on 18.06.2024.
//

import UIKit
import AVFoundation
class HomeViewController: UIViewController, AVCaptureMetadataOutputObjectsDelegate {

    
    var video = AVCaptureVideoPreviewLayer()
    let session = AVCaptureSession()
    @IBOutlet weak var cameraFrame: UIView!
    @IBOutlet weak var employeeWelcomeTitle: UILabel!
    override func viewDidLoad() {
        super.viewDidLoad()
        beginScanQr()
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
    
    private func beginScanQr() {
        
        
        let captureDevice = AVCaptureDevice.default(for: .video)
        
        do {
            let input = try AVCaptureDeviceInput(device: captureDevice!)
            session.addInput(input)
        } catch {
            fatalError(error.localizedDescription)
        }
        
        let output = AVCaptureMetadataOutput()
        session.addOutput(output)
        
        video = AVCaptureVideoPreviewLayer(session: session)
        output.setMetadataObjectsDelegate(self, queue: DispatchQueue.main)
        output.metadataObjectTypes = [AVMetadataObject.ObjectType.qr]
        video.frame = cameraFrame.bounds
        video.videoGravity = .resizeAspectFill

        
    }
    private func invokeRunning() {
        cameraFrame.layer.addSublayer(video)
        
        DispatchQueue.global().async {
            self.session.startRunning()
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
    
    func metadataOutput(_ output: AVCaptureMetadataOutput, didOutput metadataObjects: [AVMetadataObject], from connection: AVCaptureConnection) {
        
        guard metadataObjects.count > 0 else {return}
        if let object = metadataObjects.first as? AVMetadataMachineReadableCodeObject {
            if object.type == AVMetadataObject.ObjectType.qr {
                
                let shiftGuid = object.stringValue!
                
                APIManager.enterShift(ShiftEnterRequest(shiftID: shiftGuid, employeeID: CurrentData.employee!.id, tradePointID: (CurrentData.employee?.access.tradePointID)!)) { result in
                    AlertsCreator.MakePrimitiveAlert(vc: self, title: "ans", message: result, buttonTitle: "ok")
                }
                
                session.stopRunning()
                
            }
        }
        
    }
    
    @IBAction func didTapLogoutBtn(_ sender: Any) {
        CurrentData.disposeDefaults()
        self.navigationController?.popToRootViewController(animated: true)
        
    }
    
    @IBAction func didTapScanQR(_ sender: Any) {
        invokeRunning()
    }
}
