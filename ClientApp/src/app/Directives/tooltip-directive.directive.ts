import { Directive, HostListener, Input, OnInit, ComponentRef, ElementRef } from '@angular/core';
import { Overlay, OverlayRef, OverlayPositionBuilder } from '@angular/cdk/overlay';
import { ComponentPortal } from '@angular/cdk/portal';
import { TooltipComponent } from '../Components/tooltip/tooltip.component';


@Directive({
  selector: '[appTooltipDirective]'
})
export class TooltipDirectiveDirective implements OnInit {

  @Input('appTooltipDirective') text = '';

  private overlayRef: OverlayRef;

  constructor(private overlay: Overlay,
              private overlayPositionBuilder: OverlayPositionBuilder,
              private elemntRef: ElementRef) { }

  /*
  * think of the overlayRef as a remove controller, which allows us to insert some dynamically created component
  * somewhere on top of the document tree
  */
  ngOnInit(): void {
    
    const positionStrategy = this.overlayPositionBuilder
        .flexibleConnectedTo(this.elemntRef)
        .withPositions([{
          originX: 'center',
          originY: 'top',
          overlayX: 'center',
          overlayY: 'bottom',
        }]);
    
    this.overlayRef = this.overlay.create({ positionStrategy })
  }

  /*
  * overlayRef is a PortalHost --> think of a portalhost as placeholder for a component or template 
  * By creating a componentPortal and attaching it to the PortalHost, we are indicating which component to be displayed in the placeholder
  */
  @HostListener('mouseenter')
  show() {
    //create tooltip portal
    const tooltipPortal = new ComponentPortal(TooltipComponent)
    
    //attach tooltip portal to overlay
    const tooltipRef: ComponentRef<TooltipComponent> = this.overlayRef.attach(tooltipPortal)

    tooltipRef.instance.text = this.text;
  }

  @HostListener('mouseout')
  hide() {
    this.overlayRef.detach();
  }

}
