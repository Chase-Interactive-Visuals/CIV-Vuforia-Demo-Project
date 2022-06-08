//
//  Email.mm
//  EmailComposerPlugin
//
//  Created by Mayank Gupta on 06/01/15.
//  Copyright (c) 2015 Mayank Gupta. All rights reserved.
//


#import <Foundation/Foundation.h>

#import "Email.h"
#import "UnityAppController.h"
#import <MessageUI/MessageUI.h>
#import <MessageUI/MFMailComposeViewController.h>

@interface Email ()<MFMailComposeViewControllerDelegate>{
    UnityAppController *objectUnityAppController;
    NSString *msgReceivingGameObjectNameGlobal;
    NSString *msgReceivingMethodtNameGlobal;
}
@end

@implementation Email
//@synthesize library;
#pragma mark Unity bridge

+ (Email *)pluginSharedInstance {
    static Email *sharedInstance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedInstance = [[Email alloc] init];
    });
    return sharedInstance;
}

#pragma mark Ios Methods

-(void)showMailComposer{
    [self showMailComposerWithSubject:@"" Body:@"" Receiptents:@"" CCReceiptents:@"" BCCReceiptents:@""];
}

-(void)showMailComposerWithSubject:(NSString *)subjectString
                              Body:(NSString *)contentString
                       Receiptents:(NSString *)receiptentsString
                     CCReceiptents:(NSString *)ccReceiptentsString
                    BCCReceiptents:(NSString *)bccReceiptentsString
                      WithFileName:(NSString *)fileName
                       AndFileType:(NSString *)fileType{
    objectUnityAppController = GetAppController();
    MFMailComposeViewController *mc1 = [[MFMailComposeViewController alloc] init];
    if(mc1 == nil || [MFMailComposeViewController canSendMail] == false){
        [self sendMessageToUnity:@"Can not send mail on this device. Either account is not logged in Mail app or can not access it."];
        return;
    }
    
    mc1.mailComposeDelegate = self;
    NSArray *pathForDirectoriesInDomains = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES);
    NSString *documentsDirectory = [pathForDirectoriesInDomains objectAtIndex:0];
    NSString *fileAbsolutePath = [documentsDirectory stringByAppendingPathComponent:fileName];
    NSData *fileData = [NSData dataWithContentsOfFile:fileAbsolutePath];
    NSString *mimeType;
    mimeType = fileType;
    [mc1 setSubject:subjectString];
    [mc1 setMessageBody:contentString isHTML:NO];
    if(![receiptentsString isEqualToString:@""]){
        NSArray *temp_receiptents = [receiptentsString componentsSeparatedByString:@"/"];
        if(temp_receiptents.count > 0)
            [mc1 setToRecipients:temp_receiptents];
    }
    if(![ccReceiptentsString isEqualToString:@""]){
        NSArray *temp_ccReceiptents = [ccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_ccReceiptents.count > 0)
            [mc1 setCcRecipients:temp_ccReceiptents];
    }
    if(![bccReceiptentsString isEqualToString:@""]){
        NSArray *temp_bccReceiptents = [bccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_bccReceiptents.count > 0)
            [mc1 setBccRecipients:temp_bccReceiptents];
    }
    [mc1 addAttachmentData:fileData mimeType:mimeType fileName:fileName];
    [objectUnityAppController.rootViewController presentViewController:mc1 animated:YES completion:NULL];
    
}


-(void)showMailComposerWithSubject:(NSString *)subjectString
                              Body:(NSString *)contentString
                       Receiptents:(NSString *)receiptentsString
                     CCReceiptents:(NSString *)ccReceiptentsString
                    BCCReceiptents:(NSString *)bccReceiptentsString
                      AndImageName:(NSString *)imageName {
    objectUnityAppController = GetAppController();
    NSString *filename = imageName;
    MFMailComposeViewController *mc1 = [[MFMailComposeViewController alloc] init];
    if(mc1 == nil || [MFMailComposeViewController canSendMail] == false){
        [self sendMessageToUnity:@"Can not send mail on this device. Either account is not logged in Mail app or can not access it."];
        return;
    }
    
    mc1.mailComposeDelegate = self;
    NSArray *pathForDirectoriesInDomains = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory,     NSUserDomainMask, YES);
    NSString *documentsDirectory = [pathForDirectoriesInDomains objectAtIndex:0];
    NSString *getScreenshotPath = [documentsDirectory stringByAppendingPathComponent:imageName];
    NSData *fileData = [NSData dataWithContentsOfFile:getScreenshotPath];
    NSString *mimeType;
    mimeType = @"image/png";
    [mc1 setSubject:subjectString];
    [mc1 setMessageBody:contentString isHTML:NO];
    if(![receiptentsString isEqualToString:@""]){
        NSArray *temp_receiptents = [receiptentsString componentsSeparatedByString:@"/"];
        if(temp_receiptents.count > 0)
            [mc1 setToRecipients:temp_receiptents];
    }
    if(![ccReceiptentsString isEqualToString:@""]){
        NSArray *temp_ccReceiptents = [ccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_ccReceiptents.count > 0)
            [mc1 setCcRecipients:temp_ccReceiptents];
    }
    if(![bccReceiptentsString isEqualToString:@""]){
        NSArray *temp_bccReceiptents = [bccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_bccReceiptents.count > 0)
            [mc1 setBccRecipients:temp_bccReceiptents];
    }
    [mc1 addAttachmentData:fileData mimeType:mimeType fileName:filename];
    [objectUnityAppController.rootViewController presentViewController:mc1 animated:YES completion:NULL];
    
}

-(void)showMailComposerWithSubject:(NSString *)subjectString
                              Body:(NSString *)contentString
                       Receiptents:(NSString *)receiptentsString
                     CCReceiptents:(NSString *)ccReceiptentsString
       BCCReceiptentsAndScreenShot:(NSString *)bccReceiptentsString{
    objectUnityAppController = GetAppController();
    NSString *filename = @"ScreenShot";
    MFMailComposeViewController *mc1 = [[MFMailComposeViewController alloc] init];
    if(mc1 == nil || [MFMailComposeViewController canSendMail] == false){
        [self sendMessageToUnity:@"Can not send mail on this device. Either account is not logged in Mail app or can not access it."];
        return;
    }
    
    mc1.mailComposeDelegate = self;
    NSArray *pathForDirectoriesInDomains = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory,     NSUserDomainMask, YES);
    NSString *documentsDirectory = [pathForDirectoriesInDomains objectAtIndex:0];
    NSString *getScreenshotPath = [documentsDirectory stringByAppendingPathComponent:@"Screenshot.png"];
    NSData *fileData = [NSData dataWithContentsOfFile:getScreenshotPath];
    NSString *mimeType;
    mimeType = @"image/png";
    [mc1 setSubject:subjectString];
    [mc1 setMessageBody:contentString isHTML:NO];
    //NSCharacterSet *charactesSe =
    if(![receiptentsString isEqualToString:@""]){
        NSArray *temp_receiptents = [receiptentsString componentsSeparatedByString:@"/"];
        if(temp_receiptents.count > 0)
            [mc1 setToRecipients:temp_receiptents];
    }
    if(![ccReceiptentsString isEqualToString:@""]){
        NSArray *temp_ccReceiptents = [ccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_ccReceiptents.count > 0)
            [mc1 setCcRecipients:temp_ccReceiptents];
    }
    if(![bccReceiptentsString isEqualToString:@""]){
        NSArray *temp_bccReceiptents = [bccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_bccReceiptents.count > 0)
            [mc1 setBccRecipients:temp_bccReceiptents];
    }
    [mc1 addAttachmentData:fileData mimeType:mimeType fileName:filename];
    [objectUnityAppController.rootViewController presentViewController:mc1 animated:YES completion:NULL];
    
}

-(void)showMailComposerWithSubject:(NSString *)subjectString
                              Body:(NSString *)contentString
                       Receiptents:(NSString *)receiptentsString
                     CCReceiptents:(NSString *)ccReceiptentsString
                    BCCReceiptents:(NSString *)bccReceiptentsString{
    objectUnityAppController = GetAppController();
    MFMailComposeViewController *mc1 = [[MFMailComposeViewController alloc] init];
    if(mc1 == nil){
        [self sendMessageToUnity:@"Can not send mail on this device. Either account is not logged in Mail app or can not access it."];
        return;
    }
    
    mc1.mailComposeDelegate = self;
    [mc1 setSubject:subjectString];
    [mc1 setMessageBody:contentString isHTML:NO];
    if(![receiptentsString isEqualToString:@""]){
        NSArray *temp_receiptents = [receiptentsString componentsSeparatedByString:@"/"];
        if(temp_receiptents.count > 0)
            [mc1 setToRecipients:temp_receiptents];
    }
    if(![ccReceiptentsString isEqualToString:@""]){
        NSArray *temp_ccReceiptents = [ccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_ccReceiptents.count > 0)
            [mc1 setCcRecipients:temp_ccReceiptents];
    }
    if(![bccReceiptentsString isEqualToString:@""]){
        NSArray *temp_bccReceiptents = [bccReceiptentsString componentsSeparatedByString:@"/"];
        if(temp_bccReceiptents.count > 0)
            [mc1 setBccRecipients:temp_bccReceiptents];
    }
    [objectUnityAppController.rootViewController presentViewController:mc1 animated:YES completion:NULL];
    
}

- (void) mailComposeController:(MFMailComposeViewController *)controller didFinishWithResult:(MFMailComposeResult)result error:(NSError *)error
{
    NSString *resultString = @"";
    switch (result)
    {
        case MFMailComposeResultCancelled:
            resultString = @"Mail Cancelled";
            break;
        case MFMailComposeResultSaved:
            resultString = @"Mail Saved";
            break;
        case MFMailComposeResultSent:
            resultString = @"Mail Sent";
            break;
        case MFMailComposeResultFailed:
            resultString = [NSString stringWithFormat:@"Mail sent failure: %@", [error localizedDescription]];
            NSLog(@"Mail sent failure: %@", [error localizedDescription]);
            break;
        default:
            resultString = @"Something Went Wrong.";
            break;
    }
    
    [self sendMessageToUnity:resultString];
    // Close the Mail Interface
    [objectUnityAppController.rootViewController dismissViewControllerAnimated:YES completion:NULL];
}

//-------------------------------------------------------------------------------------------------

-(void) sendMessageToUnity : (NSString *) msg {
    const char *msgImageSaved = [msg cStringUsingEncoding:NSASCIIStringEncoding];
    const char *gameObjectName = [msgReceivingGameObjectNameGlobal cStringUsingEncoding:NSASCIIStringEncoding];
    const char *methodName = [msgReceivingMethodtNameGlobal cStringUsingEncoding:NSASCIIStringEncoding];
    UnitySendMessage(gameObjectName,methodName, msgImageSaved);
}

//-------------------------------------------------------------------------------------------------

-(void) setMessageCallbackMethod : (NSString *) gameObject
                                 : (NSString *) methodName
{
    msgReceivingGameObjectNameGlobal = gameObject;
    msgReceivingMethodtNameGlobal = methodName;
}


@end

// Helper method used to convert NSStrings into C-style strings.
NSString *CreateStr(const char* string) {
    if (string) {
        return [NSString stringWithUTF8String:string];
    } else {
        return [NSString stringWithUTF8String:""];
    }
}


// Unity can only talk directly to C code so use these method calls as wrappers
// into the actual plugin logic.
extern "C" {
    void _ShowMailComposer(){
        Email *objEmail = [Email pluginSharedInstance];
        [objEmail showMailComposer];
    }
    
    void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndScreenShot(const char *subjectString, const char *bodyString, const char *receiptents, const char *ccReceiptents, const char *bccReceiptents){
        Email *objEmail = [Email pluginSharedInstance];
        [objEmail showMailComposerWithSubject:CreateStr(subjectString)
                                         Body:CreateStr(bodyString)
                                  Receiptents:CreateStr(receiptents)
                                CCReceiptents:CreateStr(ccReceiptents)
                  BCCReceiptentsAndScreenShot:CreateStr(bccReceiptents)];
    }
    
    void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptents(const char *subjectString, const char *bodyString, const char *receiptents, const char *ccReceiptents, const char *bccReceiptents){
        Email *objEmail = [Email pluginSharedInstance];
        [objEmail showMailComposerWithSubject:CreateStr(subjectString)
                                         Body:CreateStr(bodyString)
                                  Receiptents:CreateStr(receiptents)
                                CCReceiptents:CreateStr(ccReceiptents)
                               BCCReceiptents:CreateStr(bccReceiptents)];
    }

    void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsAndImageName(const char *subjectString, const char *bodyString, const char *receiptents, const char *ccReceiptents, const char *bccReceiptents, const char *imageName){
        Email *objEmail = [Email pluginSharedInstance];
        [objEmail showMailComposerWithSubject:CreateStr(subjectString)
                                         Body:CreateStr(bodyString)
                                  Receiptents:CreateStr(receiptents)
                                CCReceiptents:CreateStr(ccReceiptents)
                               BCCReceiptents:CreateStr(bccReceiptents)
                                 AndImageName:CreateStr(imageName)];
    }


    void _ShowMailComposerWithSubjectBodyCCReceiptentsBCCReceiptentsWithFile(const char *subjectString, const char *bodyString, const char *receiptents, const char *ccReceiptents, const char *bccReceiptents, const char *fileName, const char *fileType){
        Email *objEmail = [Email pluginSharedInstance];
        [objEmail showMailComposerWithSubject:CreateStr(subjectString)
                                         Body:CreateStr(bodyString)
                                  Receiptents:CreateStr(receiptents)
                                CCReceiptents:CreateStr(ccReceiptents)
                               BCCReceiptents:CreateStr(bccReceiptents)
                                 WithFileName:CreateStr(fileName)
                                  AndFileType:CreateStr(fileType)];
    }



    void _SetCallbackGameObject(const char *gameObject, const char *methodName){
        Email *objEmail = [Email pluginSharedInstance];
        [objEmail setMessageCallbackMethod:CreateStr(gameObject)
                                          :CreateStr(methodName)];
    }
}
