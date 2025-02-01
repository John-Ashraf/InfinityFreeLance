import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';
import Konva from 'konva';

@Component({
  selector: 'app-design',
  imports: [FormsModule],
  templateUrl: './design.component.html',
  styleUrls: ['./design.component.css'],
})
export class DesignComponent implements OnInit {
  @ViewChild('frontStageContainer', { static: true }) frontStageContainer!: ElementRef;
  @ViewChild('backStageContainer', { static: true }) backStageContainer!: ElementRef;
  @ViewChild('rightSleeveStageContainer', { static: true }) rightSleeveStageContainer!: ElementRef;
  @ViewChild('leftSleeveStageContainer', { static: true }) leftSleeveStageContainer!: ElementRef;

  frontStage!: Konva.Stage;
  backStage!: Konva.Stage;
  rightSleeveStage!: Konva.Stage;
  leftSleeveStage!: Konva.Stage;

  frontShirtLayer!: Konva.Layer;
  backShirtLayer!: Konva.Layer;
  rightSleeveLayer!: Konva.Layer;
  leftSleeveLayer!: Konva.Layer;

  frontTextLayer!: Konva.Layer;
  backTextLayer!: Konva.Layer;
  rightSleeveTextLayer!: Konva.Layer;
  leftSleeveTextLayer!: Konva.Layer;

  frontLogoLayer!: Konva.Layer;
  backLogoLayer!: Konva.Layer;
  rightSleeveLogoLayer!: Konva.Layer;
  leftSleeveLogoLayer!: Konva.Layer;

  frontTextNode!: Konva.Text;
  backTextNode!: Konva.Text;
  rightSleeveTextNode!: Konva.Text;
  leftSleeveTextNode!: Konva.Text;

  frontUploadedImageNode: Konva.Image | null = null;
  backUploadedImageNode: Konva.Image | null = null;
  rightSleeveUploadedImageNode: Konva.Image | null = null;
  leftSleeveUploadedImageNode: Konva.Image | null = null;

  frontTransformer: Konva.Transformer | null = null;
  backTransformer: Konva.Transformer | null = null;
  rightSleeveTransformer: Konva.Transformer | null = null;
  leftSleeveTransformer: Konva.Transformer | null = null;

  color = '#000000'; // Initial shirt color

  // Separate text properties for front, back, right sleeve, and left sleeve
  frontTextInput = ''; // Text for front T-shirt
  backTextInput = ''; // Text for back T-shirt
  rightSleeveTextInput = ''; // Text for right sleeve
  leftSleeveTextInput = ''; // Text for left sleeve

  frontTextColor = '#000000'; // Text color for front T-shirt
  backTextColor = '#000000'; // Text color for back T-shirt
  rightSleeveTextColor = '#000000'; // Text color for right sleeve
  leftSleeveTextColor = '#000000'; // Text color for left sleeve

  frontFontSize = 20; // Font size for front T-shirt
  backFontSize = 20; // Font size for back T-shirt
  rightSleeveFontSize = 20; // Font size for right sleeve
  leftSleeveFontSize = 20; // Font size for left sleeve

  frontFontFamily = 'Arial'; // Font family for front T-shirt
  backFontFamily = 'Arial'; // Font family for back T-shirt
  rightSleeveFontFamily = 'Arial'; // Font family for right sleeve
  leftSleeveFontFamily = 'Arial'; // Font family for left sleeve

  currentView: 'front' | 'back' | 'right' | 'left' = 'front';

  ngOnInit() {
    this.initializeKonva();
  }

  initializeKonva() {
    this.frontStage = new Konva.Stage({
      container: this.frontStageContainer.nativeElement,
      width: 400,
      height: 420,
    });

    this.backStage = new Konva.Stage({
      container: this.backStageContainer.nativeElement,
      width: 400,
      height: 420,
    });

    this.rightSleeveStage = new Konva.Stage({
      container: this.rightSleeveStageContainer.nativeElement,
      width: 400,
      height: 420,
    });

    this.leftSleeveStage = new Konva.Stage({
      container: this.leftSleeveStageContainer.nativeElement,
      width: 400,
      height: 420,
    });

    this.initializeShirtLayer(this.frontStage, 'front');
    this.initializeShirtLayer(this.backStage, 'back');
    this.initializeShirtLayer(this.rightSleeveStage, 'right');
    this.initializeShirtLayer(this.leftSleeveStage, 'left');
  }

  initializeShirtLayer(stage: Konva.Stage, view: 'front' | 'back' | 'right' | 'left') {
    const shirtLayer = new Konva.Layer();
    const textLayer = new Konva.Layer();
    const logoLayer = new Konva.Layer();
    stage.add(shirtLayer);
    stage.add(textLayer);
    stage.add(logoLayer);

    const imageObj = new Image();
    imageObj.src = view === 'front' ? '/shirts/front.png' :
      view === 'back' ? '/shirts/back.png' :
        view === 'right' ? '/shirts/right.png' :
          '/shirts/left.png';
    imageObj.onload = () => {
      const shirtImage = new Konva.Image({
        x: 50,
        y: 50,
        image: imageObj,
        width: 300,
        height: 300,
      });

      shirtLayer.add(shirtImage);
      this.applyColorToShirt(shirtImage, shirtLayer);
      shirtLayer.draw();

      if (view === 'front') {
        this.frontShirtLayer = shirtLayer;
        this.frontTextLayer = textLayer;
        this.frontLogoLayer = logoLayer;
      } else if (view === 'back') {
        this.backShirtLayer = shirtLayer;
        this.backTextLayer = textLayer;
        this.backLogoLayer = logoLayer;
      } else if (view === 'right') {
        this.rightSleeveLayer = shirtLayer;
        this.rightSleeveTextLayer = textLayer;
        this.rightSleeveLogoLayer = logoLayer;
      } else {
        this.leftSleeveLayer = shirtLayer;
        this.leftSleeveTextLayer = textLayer;
        this.leftSleeveLogoLayer = logoLayer;
      }

      // Initialize text node for the current view
      const textNode = new Konva.Text({
        x: 150,
        y: 200,
        text: view === 'front' ? this.frontTextInput :
          view === 'back' ? this.backTextInput :
            view === 'right' ? this.rightSleeveTextInput :
              this.leftSleeveTextInput,
        fontSize: view === 'front' ? this.frontFontSize :
          view === 'back' ? this.backFontSize :
            view === 'right' ? this.rightSleeveFontSize :
              this.leftSleeveFontSize,
        fill: view === 'front' ? this.frontTextColor :
          view === 'back' ? this.backTextColor :
            view === 'right' ? this.rightSleeveTextColor :
              this.leftSleeveTextColor,
        fontFamily: view === 'front' ? this.frontFontFamily :
          view === 'back' ? this.backFontFamily :
            view === 'right' ? this.rightSleeveFontFamily :
              this.leftSleeveFontFamily,
        draggable: true,
      });

      textLayer.add(textNode);
      textLayer.draw();

      if (view === 'front') {
        this.frontTextNode = textNode;
      } else if (view === 'back') {
        this.backTextNode = textNode;
      } else if (view === 'right') {
        this.rightSleeveTextNode = textNode;
      } else {
        this.leftSleeveTextNode = textNode;
      }
    };
  }

  applyColorToShirt(shirtImage: Konva.Image, shirtLayer: Konva.Layer) {
    const rgb = this.hexToRgb(this.color);
    if (rgb && shirtImage) {
      shirtImage.cache();
      shirtImage.filters([Konva.Filters.RGBA]);
      shirtImage.red(rgb[0]);
      shirtImage.green(rgb[1]);
      shirtImage.blue(rgb[2]);
      shirtLayer.draw();
    }
  }

  hexToRgb(hex: string): [number, number, number] | null {
    if (!/^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$/.test(hex)) {
      console.error('Invalid hex color code');
      return null;
    }

    const bigint = parseInt(hex.slice(1), 16);
    const r = (bigint >> 16) & 255;
    const g = (bigint >> 8) & 255;
    const b = bigint & 255;
    return [r, g, b];
  }

  updateShirtColor(color: string) {
    this.color = color;
    this.applyColorToShirt(this.frontShirtLayer.getChildren()[0] as Konva.Image, this.frontShirtLayer);
    this.applyColorToShirt(this.backShirtLayer.getChildren()[0] as Konva.Image, this.backShirtLayer);
    this.applyColorToShirt(this.rightSleeveLayer.getChildren()[0] as Konva.Image, this.rightSleeveLayer);
    this.applyColorToShirt(this.leftSleeveLayer.getChildren()[0] as Konva.Image, this.leftSleeveLayer);
  }

  // Getter and setter for text input
  get textInput(): string {
    return this.currentView === 'front' ? this.frontTextInput :
      this.currentView === 'back' ? this.backTextInput :
        this.currentView === 'right' ? this.rightSleeveTextInput :
          this.leftSleeveTextInput;
  }
  set textInput(value: string) {
    if (this.currentView === 'front') {
      this.frontTextInput = value;
    } else if (this.currentView === 'back') {
      this.backTextInput = value;
    } else if (this.currentView === 'right') {
      this.rightSleeveTextInput = value;
    } else {
      this.leftSleeveTextInput = value;
    }
    this.updateTextSettings();
  }

  // Getter and setter for text color
  get textColor(): string {
    return this.currentView === 'front' ? this.frontTextColor :
      this.currentView === 'back' ? this.backTextColor :
        this.currentView === 'right' ? this.rightSleeveTextColor :
          this.leftSleeveTextColor;
  }
  set textColor(value: string) {
    if (this.currentView === 'front') {
      this.frontTextColor = value;
    } else if (this.currentView === 'back') {
      this.backTextColor = value;
    } else if (this.currentView === 'right') {
      this.rightSleeveTextColor = value;
    } else {
      this.leftSleeveTextColor = value;
    }
    this.updateTextSettings();
  }

  // Getter and setter for font size
  get fontSize(): number {
    return this.currentView === 'front' ? this.frontFontSize :
      this.currentView === 'back' ? this.backFontSize :
        this.currentView === 'right' ? this.rightSleeveFontSize :
          this.leftSleeveFontSize;
  }
  set fontSize(value: number) {
    if (this.currentView === 'front') {
      this.frontFontSize = value;
    } else if (this.currentView === 'back') {
      this.backFontSize = value;
    } else if (this.currentView === 'right') {
      this.rightSleeveFontSize = value;
    } else {
      this.leftSleeveFontSize = value;
    }
    this.updateTextSettings();
  }

  // Getter and setter for font family
  get fontFamily(): string {
    return this.currentView === 'front' ? this.frontFontFamily :
      this.currentView === 'back' ? this.backFontFamily :
        this.currentView === 'right' ? this.rightSleeveFontFamily :
          this.leftSleeveFontFamily;
  }
  set fontFamily(value: string) {
    if (this.currentView === 'front') {
      this.frontFontFamily = value;
    } else if (this.currentView === 'back') {
      this.backFontFamily = value;
    } else if (this.currentView === 'right') {
      this.rightSleeveFontFamily = value;
    } else {
      this.leftSleeveFontFamily = value;
    }
    this.updateTextSettings();
  }

  updateTextSettings() {
    if (this.currentView === 'front') {
      if (this.frontTextNode) {
        this.frontTextNode.text(this.frontTextInput);
        this.frontTextNode.fontSize(this.frontFontSize);
        this.frontTextNode.fill(this.frontTextColor);
        this.frontTextNode.fontFamily(this.frontFontFamily);
        this.frontTextLayer.draw();
      }
    } else if (this.currentView === 'back') {
      if (this.backTextNode) {
        this.backTextNode.text(this.backTextInput);
        this.backTextNode.fontSize(this.backFontSize);
        this.backTextNode.fill(this.backTextColor);
        this.backTextNode.fontFamily(this.backFontFamily);
        this.backTextLayer.draw();
      }
    } else if (this.currentView === 'right') {
      if (this.rightSleeveTextNode) {
        this.rightSleeveTextNode.text(this.rightSleeveTextInput);
        this.rightSleeveTextNode.fontSize(this.rightSleeveFontSize);
        this.rightSleeveTextNode.fill(this.rightSleeveTextColor);
        this.rightSleeveTextNode.fontFamily(this.rightSleeveFontFamily);
        this.rightSleeveTextLayer.draw();
      }
    } else {
      if (this.leftSleeveTextNode) {
        this.leftSleeveTextNode.text(this.leftSleeveTextInput);
        this.leftSleeveTextNode.fontSize(this.leftSleeveFontSize);
        this.leftSleeveTextNode.fill(this.leftSleeveTextColor);
        this.leftSleeveTextNode.fontFamily(this.leftSleeveFontFamily);
        this.leftSleeveTextLayer.draw();
      }
    }
  }

  switchView(view: 'front' | 'back' | 'right' | 'left') {
    this.currentView = view;
    this.frontStageContainer.nativeElement.style.display = view === 'front' ? 'block' : 'none';
    this.backStageContainer.nativeElement.style.display = view === 'back' ? 'block' : 'none';
    this.rightSleeveStageContainer.nativeElement.style.display = view === 'right' ? 'block' : 'none';
    this.leftSleeveStageContainer.nativeElement.style.display = view === 'left' ? 'block' : 'none';
  }

  onFileSelect(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        const imageObj = new Image();
        imageObj.src = e.target.result;
        imageObj.onload = () => {
          const currentStage = this.currentView === 'front' ? this.frontStage :
            this.currentView === 'back' ? this.backStage :
              this.currentView === 'right' ? this.rightSleeveStage :
                this.leftSleeveStage;
          const currentLogoLayer = this.currentView === 'front' ? this.frontLogoLayer :
            this.currentView === 'back' ? this.backLogoLayer :
              this.currentView === 'right' ? this.rightSleeveLogoLayer :
                this.leftSleeveLogoLayer;
          const currentUploadedImageNode = this.currentView === 'front' ? this.frontUploadedImageNode :
            this.currentView === 'back' ? this.backUploadedImageNode :
              this.currentView === 'right' ? this.rightSleeveUploadedImageNode :
                this.leftSleeveUploadedImageNode;
          const currentTransformer = this.currentView === 'front' ? this.frontTransformer :
            this.currentView === 'back' ? this.backTransformer :
              this.currentView === 'right' ? this.rightSleeveTransformer :
                this.leftSleeveTransformer;

          if (currentUploadedImageNode) {
            currentUploadedImageNode.destroy();
            currentTransformer?.destroy();
          }

          const uploadedImageNode = new Konva.Image({
            x: 150,
            y: 150,
            image: imageObj,
            width: 100,
            height: 100,
            draggable: true,
          });

          currentLogoLayer.add(uploadedImageNode);

          const transformer = new Konva.Transformer({
            node: uploadedImageNode,
            enabledAnchors: ['top-left', 'top-right', 'bottom-left', 'bottom-right'],
            visible: false,
          });

          currentLogoLayer.add(transformer);

          uploadedImageNode.on('mouseenter', () => {
            this.showTransformer(transformer, currentLogoLayer);
          });

          currentStage.on('click', () => {
            this.resetTransformerTimer(transformer, currentLogoLayer);
          });

          currentLogoLayer.draw();

          if (this.currentView === 'front') {
            this.frontUploadedImageNode = uploadedImageNode;
            this.frontTransformer = transformer;
          } else if (this.currentView === 'back') {
            this.backUploadedImageNode = uploadedImageNode;
            this.backTransformer = transformer;
          } else if (this.currentView === 'right') {
            this.rightSleeveUploadedImageNode = uploadedImageNode;
            this.rightSleeveTransformer = transformer;
          } else {
            this.leftSleeveUploadedImageNode = uploadedImageNode;
            this.leftSleeveTransformer = transformer;
          }
        };
        imageObj.onerror = () => {
          console.error('Failed to load uploaded image');
        };
      };
      reader.readAsDataURL(input.files[0]);
    }
  }

  showTransformer(transformer: Konva.Transformer, logoLayer: Konva.Layer) {
    if (transformer) {
      transformer.visible(true);
      logoLayer.draw();
      this.resetTransformerTimer(transformer, logoLayer);
    }
  }

  hideTransformer(transformer: Konva.Transformer, logoLayer: Konva.Layer) {
    if (transformer) {
      transformer.visible(false);
      logoLayer.draw();
    }
  }

  resetTransformerTimer(transformer: Konva.Transformer, logoLayer: Konva.Layer) {
    setTimeout(() => {
      this.hideTransformer(transformer, logoLayer);
    }, 3000);
  }

  deleteLogo() {
    if (this.currentView === 'front') {
      if (this.frontUploadedImageNode) {
        this.frontUploadedImageNode.destroy();
        this.frontUploadedImageNode = null;
        if (this.frontTransformer) {
          this.frontTransformer.destroy();
          this.frontTransformer = null;
        }
        this.frontLogoLayer.draw();
      }
    } else if (this.currentView === 'back') {
      if (this.backUploadedImageNode) {
        this.backUploadedImageNode.destroy();
        this.backUploadedImageNode = null;
        if (this.backTransformer) {
          this.backTransformer.destroy();
          this.backTransformer = null;
        }
        this.backLogoLayer.draw();
      }
    } else if (this.currentView === 'right') {
      if (this.rightSleeveUploadedImageNode) {
        this.rightSleeveUploadedImageNode.destroy();
        this.rightSleeveUploadedImageNode = null;
        if (this.rightSleeveTransformer) {
          this.rightSleeveTransformer.destroy();
          this.rightSleeveTransformer = null;
        }
        this.rightSleeveLogoLayer.draw();
      }
    } else {
      if (this.leftSleeveUploadedImageNode) {
        this.leftSleeveUploadedImageNode.destroy();
        this.leftSleeveUploadedImageNode = null;
        if (this.leftSleeveTransformer) {
          this.leftSleeveTransformer.destroy();
          this.leftSleeveTransformer = null;
        }
        this.leftSleeveLogoLayer.draw();
      }
    }
  }

  saveDesign() {
    const frontDataURL = this.frontStage.toDataURL();
    const backDataURL = this.backStage.toDataURL();
    const rightSleeveDataURL = this.rightSleeveStage.toDataURL();
    const leftSleeveDataURL = this.leftSleeveStage.toDataURL();

    const frontLink = document.createElement('a');
    frontLink.download = 'front-shirt-design.png';
    frontLink.href = frontDataURL;
    frontLink.click();

    const backLink = document.createElement('a');
    backLink.download = 'back-shirt-design.png';
    backLink.href = backDataURL;
    backLink.click();

    const rightSleeveLink = document.createElement('a');
    rightSleeveLink.download = 'right-sleeve-design.png';
    rightSleeveLink.href = rightSleeveDataURL;
    rightSleeveLink.click();

    const leftSleeveLink = document.createElement('a');
    leftSleeveLink.download = 'left-sleeve-design.png';
    leftSleeveLink.href = leftSleeveDataURL;
    leftSleeveLink.click();
  }
}